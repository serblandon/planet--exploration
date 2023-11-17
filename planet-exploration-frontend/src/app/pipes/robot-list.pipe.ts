import { Pipe, PipeTransform } from "@angular/core";
import { IRobot } from "../interfaces/robot";

@Pipe({name: 'robotList'})
export class RobotListPipe implements PipeTransform {
  transform(robots: IRobot[]): string {
    return robots.map(robot => robot.name).join(', ');
  }
}