export interface Policy{
    policyId: number;
    title: string;
    description: string;
    startDate: string;
    endDate: string;
    insuredAmount: number;
    insuredName:string;
    insuredHolderAge: number;
    policyTypeId: number;
    vehicleModel:string;
    vehicleNumber:string;
    houseAddress:string;
    assetValue:number;
    coverageId: number;
}