import { BaseModel } from "./base.model";

export interface MembershipStatus extends BaseModel{
    id:string;
    name: string;
    description: string;
}