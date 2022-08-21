import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {ClientComponent} from './components/client/client.component';
import {ProductComponent} from './components/product/product.component';
import {LicenseComponent} from './components/license/license.component';
import {HomeComponent} from './components/home/home.component';

const routes: Routes = [
  {path:'client', component:ClientComponent},
  {path:'product', component:ProductComponent},
  {path:'license', component:LicenseComponent},
  {path:'', component:HomeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
