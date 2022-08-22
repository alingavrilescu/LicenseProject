import { Component, OnInit } from '@angular/core';
import { Guid } from 'guid-typescript';
import { Client } from 'src/app/models/client';
import { License } from 'src/app/models/license';
import { Product } from 'src/app/models/product';
import { ClientService } from 'src/app/services/client.service';
import { LicenseService } from 'src/app/services/license.service';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-license',
  templateUrl: './license.component.html',
  styleUrls: ['./license.component.css']
})
export class LicenseComponent implements OnInit {

  constructor(private service:LicenseService, private serviceProduct:ProductService, private serviceClient:ClientService) {}

  licenseList:License[]=[];
  productList:Product[]=[];
  clientList:Client[]=[];
  clientToCreateLic!:Guid;
  productToCreateLic!:Guid;

  licenseContent="";
  licenseType ="";
  dateValue ="2022-08-22T15:31:44.779Z";

  display = "none";

  ngOnInit(): void {
    this.refreshLicenseList();
    this.refreshClientList();
    this.refreshProductList();
  }

  addLicense()
  {
    var val={
      licenseType:this.licenseType,
      expiration:this.dateValue,
      clientId:this.clientToCreateLic,
      productId:this.productToCreateLic
    };
    this.service.createLicense(val).subscribe(res=>{alert(res.toString());});
    this.display = "none";
    window.location.reload();
    // console.log(this.dateValue);
  }

  deleteLicense(item : License){
      this.service.deleteLicense(item).subscribe(data=>{
        alert(data.toString());
      })
      window.location.reload();
  }

  refreshLicenseList()
  {
    this.service.getLicense().subscribe(data=>{
      this.licenseList=data;
    })
  }

  refreshClientList()
  {
    this.serviceClient.getClient().subscribe(data=>{
      this.clientList=data;
    })
  }

  refreshProductList()
  {
    this.serviceProduct.getProduct().subscribe(data=>{
      this.productList=data;
    })
  }

  download(text:string) {
    var element = document.createElement('a');
    element.setAttribute('href', 'data:text/plain;charset=utf-8,' + encodeURIComponent(text));
    element.setAttribute('download', 'License.lic');
  
    element.style.display = 'none';
    document.body.appendChild(element);
  
    element.click();
  
    document.body.removeChild(element);
  }

  openModal() {
    this.display = "block";
  }
  onCloseHandled() {
    this.display = "none";
  }

  dataChanged($event:any){
    this.dateValue=$event.target.value;
  }
  
  // getProduct(id : Guid)
  // {
  //   this.serviceProduct.getProductById(id).subscribe(data=>{
  //     this.product=data;
  //   })
  // }

  // getClient(id : Guid)
  // {
  //   this.serviceClient.getClientById(id).subscribe(data=>{
  //     this.client=data;
  //   })
  // }
}
