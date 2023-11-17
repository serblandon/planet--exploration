import { Planet } from "./planet";

export interface Robot {
    id: number;
    name: string;
    planetId: number;
    planet?: Planet;
}