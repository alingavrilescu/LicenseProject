import { Component, OnInit } from '@angular/core';
import { Client } from 'src/app/models/client';
import { ClientService } from 'src/app/services/client.service';

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.css']
})
export class ClientComponent implements OnInit {

  constructor(private service:ClientService) { }

  clientList:Client[]=[];

  clientName="";
  clientEmail="";

  display = "none";

  ngOnInit(): void {
    this.refreshClientList();
  }

  addClient()
  {
    var val={
      name:this.clientName,
      email:this.clientEmail
    };
    this.service.createClient(val).subscribe(res=>{alert(res.toString());
    });
    this.display = "none";
    window.location.reload();
  }

  deleteClient(item : Client){
      this.service.deleteClient(item).subscribe(data=>{
        alert(data.toString());
      })
      // this.refreshClientList();
      window.location.reload();
  }

  refreshClientList()
  {
    this.service.getClient().subscribe(data=>{
      this.clientList=data;
    })
  }
  
  openModal() {
    this.display = "block";
  }
  onCloseHandled() {
    this.display = "none";
  }
}
