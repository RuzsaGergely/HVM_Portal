import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent {
  constructor(private router: Router) {}

  logout() {
    // Itt lehetne a kijelentkezés logikát implementálni
    // Példa: a bejelentkezési oldalra navigálás
    this.router.navigateByUrl('/login');
  }
}
