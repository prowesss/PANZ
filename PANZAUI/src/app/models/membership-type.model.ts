import { BaseModel } from "./base.model";

export interface MembershipType extends BaseModel{
    id:string;
    name: string;
    cost: number;
    noOfYears: number;
    stripePriceId: string;
}