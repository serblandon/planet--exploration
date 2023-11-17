import { HumanCaptain } from "./human-captain";
import { Robot } from "./robot";

export interface Planet {
    id: number;
    name: string;
    description?: string;
    status: string;
    humanCaptain: HumanCaptain;
    robots: Robot[];
}