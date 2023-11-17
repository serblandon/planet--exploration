import { Planet } from "./planet";

export interface HumanCaptain {
    id: number;
    name: string;
    planetId: number;
    planet?: Planet;
}