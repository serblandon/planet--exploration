import { IPlanet } from "./planet";

export interface IHumanCaptain {
    id: number;
    name: string;
    planetId: number;
    planet?: IPlanet;
}