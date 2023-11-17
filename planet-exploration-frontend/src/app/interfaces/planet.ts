import { IHumanCaptain } from "./human-captain";
import { IRobot } from "./robot";

export interface IPlanet {
    id: number;
    name: string;
    description?: string;
    status: string;
    humanCaptain: IHumanCaptain;
    robots: IRobot[];
}