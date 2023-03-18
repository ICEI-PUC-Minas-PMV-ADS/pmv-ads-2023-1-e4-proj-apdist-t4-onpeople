import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';


@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  public isCollapsed = true;

  constructor(private router: Router) { }

  ngOnInit() {
  }

  public showMenu(): boolean {
    return this.router.url !== '/contas/login'
  }
}
