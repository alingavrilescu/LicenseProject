import { Guid } from 'guid-typescript';
export class Product{
    id? :Guid;
    name ="";
    description="";
    passPhase="";
    encryptedPrivateKey="";
    publicKey="";
}