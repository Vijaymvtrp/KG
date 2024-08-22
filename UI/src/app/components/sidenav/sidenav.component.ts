import { Component } from '@angular/core';
import { DashboardComponent } from "../dashboard/dashboard.component";
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { RoomsComponent } from '../rooms/rooms.component';

@Component({
  selector: 'app-sidenav',
  standalone: true,
  imports: [DashboardComponent,RoomsComponent,
    MatSidenavModule, MatListModule,RouterLink,RouterLinkActive,RouterOutlet],
  templateUrl: './sidenav.component.html',
  styleUrl: './sidenav.component.scss'
})
export class SidenavComponent {

}
