import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FeatureComponent } from './feature/feature.component';
import { CardComponent } from './card/card.component';
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatSelectModule} from "@angular/material/select";
import {MatInputModule} from "@angular/material/input";
import { BulletPointComponent } from './bullet-point/bullet-point.component';
import {MatDatepickerModule} from "@angular/material/datepicker";
import {MatNativeDateModule} from "@angular/material/core";
import { NgxMatDatetimePickerModule, NgxMatTimepickerModule, NgxMatNativeDateModule } from '@angular-material-components/datetime-picker';
import {HttpClientModule} from "@angular/common/http";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {MatButtonModule} from "@angular/material/button";
import {MatCardModule} from "@angular/material/card";
import { LunchMenuComponent } from './lunch-menu/lunch-menu.component';
import {RouterModule, Routes} from "@angular/router";
import { HomeComponent } from './home/home.component';
import { AdminComponent } from './admin/admin.component';
import { ReservationComponent } from './reservation/reservation.component';
import { CreateReservationFormComponent } from './create-reservation-form/create-reservation-form.component';


//routing
const appRoutes: Routes = [
  {path:'', component: HomeComponent},
  {path: 'admin', component: AdminComponent}
]

@NgModule({
  declarations: [
    AppComponent,
    FeatureComponent,
    CardComponent,
    BulletPointComponent,
    LunchMenuComponent,
    HomeComponent,
    AdminComponent,
    ReservationComponent,
    CreateReservationFormComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
    HttpClientModule,
    NgxMatTimepickerModule,
    FormsModule,
    ReactiveFormsModule,
    MatButtonModule,
    NgxMatDatetimePickerModule,
    NgxMatNativeDateModule,
    MatCardModule,
    //routing
    RouterModule.forRoot(appRoutes)
  ],
  exports:[RouterModule],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
