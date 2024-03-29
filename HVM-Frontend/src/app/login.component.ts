import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  username: string;
  password: string;

  constructor(private router: Router) {}

  login() {
    // Itt lehetne a bejelentkezési logika
    // Példa: ha a bejelentkezés sikeres, akkor navigálj a főoldalra
    if (this.username === 'felhasznalonev' && this.password === 'jelszo') {
      this.router.navigateByUrl('/main');
    } else {
      // Hibaüzenet megjelenítése vagy egyéb kezelés
      alert('Hibás felhasználónév vagy jelszó!');
    }
  }
}
