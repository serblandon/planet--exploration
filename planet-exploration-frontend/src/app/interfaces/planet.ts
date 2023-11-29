import { IHumanCaptain } from "./human-captain";
import { IRobot } from "./robot";

export interface IPlanet {
    id: number;
    name: string;
    description?: string;
    status: number;
    imageUrl: string;
    humanCaptain: IHumanCaptain;
    robots: IRobot[];
}