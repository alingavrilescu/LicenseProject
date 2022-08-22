import { Guid } from 'guid-typescript';
import { Client } from './client';
import { Product } from './product';
export class License{
    id? :Guid;
    licenseContent="";
    licenseType="";
    expiration ="";
    product!:Product;
    client!:Client;
}