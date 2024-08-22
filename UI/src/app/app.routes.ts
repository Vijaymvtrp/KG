import { Routes } from '@angular/router';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { RoomsComponent } from './components/rooms/rooms.component';
import { NewbookingComponent } from './components/newbooking/newbooking.component';
import { BookinghistoryComponent } from './components/bookinghistory/bookinghistory.component';
import { AdvancebookingsComponent } from './components/advancebookings/advancebookings.component';
import { RemindersComponent } from './components/reminders/reminders.component';
import { TransactionsComponent } from './components/transactions/transactions.component';
import { SettingsComponent } from './components/settings/settings.component';

export const routes: Routes = [
  {path: 'dashboard' , component: DashboardComponent},
  {path: 'newbooking' , component: NewbookingComponent},
  {path: 'rooms' , component: RoomsComponent},
  {path: 'bookinghistory' , component: BookinghistoryComponent},
  {path: 'advancebookings' , component: AdvancebookingsComponent},
  {path: 'reminders' , component: RemindersComponent},
  {path: 'transactions' , component: TransactionsComponent},
  {path: 'settings' , component: SettingsComponent},

];
