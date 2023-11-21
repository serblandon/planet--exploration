import { IHumanCaptain } from "./human-captain";
import { IRobot } from "./robot";

export interface IPlanet {
    id: number;
    name: string;
    description?: string;
    status: number;
    humanCaptain: IHumanCaptain;
    robots: IRobot[];
}