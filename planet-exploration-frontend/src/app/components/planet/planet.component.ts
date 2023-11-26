import { Component, Input, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IHumanCaptain } from 'src/app/interfaces/human-captain';
import { IPlanet } from 'src/app/interfaces/planet';
import { IRobot } from 'src/app/interfaces/robot';
import { HumanCaptainService } from 'src/app/services/human-captain.service';
import { PlanetService } from 'src/app/services/planet.service';
import { RobotService } from 'src/app/services/robot.service';
@Component({
  selector: 'app-planet',
  templateUrl: './planet.component.html',
  styleUrls: ['./planet.component.css']
})

export class PlanetComponent implements OnInit{

  @Input()
  public planet!: IPlanet;

  public humanCaptains: IHumanCaptain[] = [];
  public robotsDb: IRobot[] = [];

  public planetForm!: FormGroup;
  editMode: boolean = false;

  constructor(
    private planetService: PlanetService,
    private humanCaptainService: HumanCaptainService,
    private robotService: RobotService,
    private fb: FormBuilder
    ) { }

    ngOnInit(): void {
      this.createForm();
      this.loadHumanCaptains();
      this.loadRobotsDb();
    }

    createForm() {
      this.planetForm = this.fb.group({
        description: [this.planet?.description ?? '', Validators.required],
        status: [this.planet?.status || '', Validators.required],
        humanCaptainName: [this.planet?.humanCaptain?.name || '', Validators.required],
        robots: this.fb.array(this.planet?.robots?.map(robot => this.fb.group({ name: robot.name })) || [])
      });
    }

    toggleEditMode() {
      this.editMode = !this.editMode;
      if (this.editMode) {
        this.populateForm();
      }
    }

    populateForm() {
      this.planetForm.patchValue({
        description: this.planet.description,
        status: this.planet.status,
        humanCaptainName: this.planet.humanCaptain?.name
      });
      this.setRobots(this.planet.robots);
    }

    setRobots(robots: any[]) {
      const robotFGs = robots.map(robot => this.fb.group(robot));
      const robotFormArray = this.fb.array(robotFGs);
      this.planetForm.setControl('robots', robotFormArray);
    }

    get robots(): FormArray {
      return this.planetForm.get('robots') as FormArray;
    }
  
    addRobot() {
      const robotFormGroup = this.fb.group({
        name: ['', Validators.required],
      });
      this.robots.push(robotFormGroup);
    }

    removeRobot(index: number) {
      this.robots.removeAt(index);
    }

    // submitUpdate() {
    //   if (this.planetForm.valid) {
    //     const updatedPlanet: IPlanet = {
    //       ...this.planet,
    //       ...this.planetForm.value,
    //       humanCaptain: { ...this.planet.humanCaptain, name: this.planetForm.value.humanCaptainName },
    //       robots: this.planetForm.value.robots
    //     };
  
    //     this.planetService.update(updatedPlanet, updatedPlanet.id).subscribe({
    //       next: (response) => {
    //         console.log('Planet updated successfully:', response);
    //         this.toggleEditMode();
    //       },
    //       error: (error) => {
    //         console.error('Error updating planet:', error);
    //       }
    //     });
    //   }
    // }

    submitUpdate() {
      if (this.planetForm.valid) {
        const formModel = this.planetForm.value;

        const selectedHumanCaptain = this.humanCaptains.find(
          captain => captain.name === formModel.humanCaptainName
        );

        const selectedRobots = formModel.robots.map((formRobot: any) => {
          const foundRobot = this.robotsDb.find(robot => robot.name === formRobot.name);
          if (!foundRobot) {
            console.error(`No matching robot found for name: ${formRobot.name}`);
            return null;  // or handle this case as you see fit
          }
          return foundRobot;
        }).filter((robot: IRobot | null) => robot !== null);
    
        // Construct the data to be sent in the PUT request
        const updatedData= {
          ...this.planet,
          description: formModel.description,
          status: Number(formModel.status),
          humanCaptain: selectedHumanCaptain!,
          robots: selectedRobots
        };
    
        this.planetService.update(updatedData, this.planet.id).subscribe({
          next: (response) => {
            console.log('Planet updated successfully:', response);
            this.toggleEditMode(); // Optionally toggle edit mode off
          },
          error: (error) => {
            console.error('Error updating planet:', error);
          }
        });
      }
    }
    

    loadHumanCaptains() {
      this.humanCaptainService.getAll().subscribe({
        next: (captains) => {
          this.humanCaptains = captains;
        },
        error: (error) => {
          console.error('Error fetching human captains:', error);
        }
      });
    }

    loadRobotsDb() {
      this.robotService.getAll().subscribe({
        next: (robotsDb) => {
          this.robotsDb = robotsDb;
        },
        error: (error) => {
          console.error('Error fetching human captains:', error);
        }
      });
    }
}
