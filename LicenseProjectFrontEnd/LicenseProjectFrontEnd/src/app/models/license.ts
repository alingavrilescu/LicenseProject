import { Guid } from 'guid-typescript';
export class License{
    id? :Guid;
    licenseType ="";
    expiration ="";
    productId? :Guid;
    clientId? :Guid;
}