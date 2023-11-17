import { IPlanet } from "./planet";

export interface IRobot {
    id: number;
    name: string;
    planetId: number;
    planet?: IPlanet;
}