import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent {
  name: string;
  password: string;
  phoneNumber: string;
  address: string;
  email: string;

  constructor(private router: Router) {}

  register() {
    // Itt lehetne a regisztrációs logika
    // Példa: ha a regisztráció sikeres, akkor navigálj a bejelentkező oldalra
    this.router.navigateByUrl('/login');
  }
}
