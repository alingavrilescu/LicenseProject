import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/models/product';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  constructor(private service:ProductService) { }

  productList:Product[]=[];

  productName="";
  productDescription="";
  productPassPhase="";

  display = "none";

  ngOnInit(): void {
    this.refreshProductList();
  }

  addProduct()
  {
    var val={
      name:this.productName,
      description:this.productDescription,
      passPhase:this.productPassPhase,
      encryptedPrivateKey:"",
      publicKey:""
    };
    this.service.createProduct(val).subscribe(res=>{alert(res.toString());
    });
    this.display = "none";
    window.location.reload();
  }

  deleteProduct(item : Product){
      this.service.deleteProduct(item).subscribe(data=>{
        alert(data.toString());
      })
      // this.refreshProductList();
      window.location.reload();
  }

  refreshProductList()
  {
    this.service.getProduct().subscribe(data=>{
      this.productList=data;
    })
  }

  download(text:string) {
    var element = document.createElement('a');
    element.setAttribute('href', 'data:text/plain;charset=utf-8,' + encodeURIComponent(text));
    element.setAttribute('download', 'PublicKey.txt');
  
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
}
