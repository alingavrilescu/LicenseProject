import { Guid } from 'guid-typescript';
export class LicenseToSend{
    id? :Guid;
    licenseType="";
    expiration ="";
    productId!:Guid;
    clientId!:Guid;
}