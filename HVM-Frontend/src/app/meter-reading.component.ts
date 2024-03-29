import { Component } from '@angular/core';

@Component({
  selector: 'app-meter-reading',
  templateUrl: './meter-reading.component.html',
  styleUrls: ['./meter-reading.component.css']
})
export class MeterReadingComponent {
  meterType: string;
  meter: string;
  meterReading: number;
  imageUrl: string;

  onFileSelected(event: any) {
    const file = event.target.files[0];
    const reader = new FileReader();
    reader.onload = () => {
      this.imageUrl = reader.result as string;
    };
    reader.readAsDataURL(file);
  }

  clear() {
    this.meterType = '';
    this.meter = '';
    this.meterReading = null;
    this.imageUrl = null;
  }

  confirm() {
    const confirmation = confirm('Biztosan el akarja küldeni a mérőóra állását?');
    if (confirmation) {
      // Itt lehetne az adatok elküldése
      alert('Mérőóra állás elküldve!');
      this.clear();
    }
  }
}
