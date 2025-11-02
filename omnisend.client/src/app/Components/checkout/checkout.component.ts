import { Component, HostListener, OnInit } from '@angular/core';
import { CheckoutService } from '../../Services/checkout.service';

@Component({
  selector: 'app-checkout',
  standalone: false,
  templateUrl: './checkout.component.html',
  styleUrl: './checkout.component.css',
})
export class CheckoutComponent implements OnInit {
  price = 100;
  discountedPrice = this.price;
  discountApplied = false;
  showPopup = false;
  popupShownOnce = false;
  response: any;
  productTitle = 'Stylish Sneakers';

  constructor(private omnisend: CheckoutService) {}
  ngOnInit(): void {}

  // Detect mouse leaving window top (exit intent)
  @HostListener('document:mousemove', ['$event'])
  onMouseMove(event: MouseEvent) {
    if (!this.popupShownOnce && event.clientY <= 25) {
      this.showPopup = true;
      this.popupShownOnce = true;
    }
  }

  // User clicked "Proceed to Checkout"
  startCheckout() {
    const payload = {
      origin: 'api',
      eventID: crypto.randomUUID(),
      eventName: 'Started Checkout',
      eventVersion: '',
      eventTime: new Date().toISOString(),
      properties: {
        abandonedCheckoutURL: 'https://example.com/checkout',
        cartID: 'cart123',
        currency: 'EUR',
        lineItems: [
          {
            productCategories: [{ id: '123', title: 'Shoes' }],
            productDescription: 'The best product ever!',
            productDiscount: 10.19,
            productID: '1',
            productImageURL: 'https://example.com/product.jpg',
            productPrice: this.discountApplied
              ? this.discountedPrice
              : this.price,
            productQuantity: 1,
            productSKU: '200',
            productStrikeThroughPrice: 120.0,
            productTitle: this.productTitle,
            productURL: 'https://example.com/product/1',
            productVariantID: '123',
            productVariantImageURL: 'https://example.com/product-variant.jpg',
          },
        ],
        value: this.discountApplied ? this.discountedPrice : this.price,
      },
      contact: {
        id: '67447b7d5c1cd54488ec24d9',
        email: 'c59933290@gmail.com',
        phone: '+443031237300',
        firstName: 'Chandan',
        lastName: 'Chauhan',
        city: 'New York',
        country: 'United States',
        countryCode: 'US',
      },
    };

    this.omnisend.sendStartedCheckout(payload).subscribe({
      next: (res) => (this.response = res),
      error: (err) => (this.response = err),
    });
  }

  // Apply 20% discount
  applyDiscount() {
    this.discountApplied = true;
    this.discountedPrice = +(this.price * 0.8).toFixed(2);
    this.showPopup = false;
    alert('🎉 20% discount applied to your total!');
  }

  // Close popup without applying offer
  closePopup() {
    this.showPopup = false;
  }

  // constructor(private omnisendService: CheckoutService) {}
  // ngOnInit(): void {
  //   this.sendCheckoutEvent();
  // }

  // sendCheckoutEvent(): void {
  //   const checkoutData = {
  //     origin: 'api',
  //     eventID: 'f3f61bc6-07b8-4645-92d8-189d882dbcb1',
  //     eventVersion: '',
  //     eventTime: new Date().toISOString(),
  //     properties: {
  //       abandonedCheckoutURL: 'https://example.com/checkout',
  //       cartID: 'a342-dsfv12',
  //       currency: 'EUR',
  //       lineItems: [
  //         {
  //           productCategories: [{ id: '123', title: 'Shoes' }],
  //           productDescription: 'The best product with many various features',
  //           productDiscount: 10.19,
  //           productID: '1',
  //           productImageURL: 'https://example.com/product/232423-image.jpg',
  //           productPrice: 19.99,
  //           productQuantity: 2,
  //           productSKU: 200,
  //           productStrikeThroughPrice: 29.99,
  //           productTitle: 'The best product',
  //           productURL: 'https://example.com/product/232423',
  //           productVariantID: '123',
  //           productVariantImageURL:
  //             'https://example.com/product/232423-variant-image.jpg',
  //         },
  //       ],
  //       value: 19.99,
  //     },
  //     contact: {
  //       id: '67447b7d5c1cd54488ec24d8',
  //       email: 'chandan@inestweb.com',
  //       firstName: 'Chandan',
  //       lastName: 'Chauhan',
  //       country: 'United States',
  //     },
  //   };
  //   this.omnisendService.trackStartedCheckout(checkoutData);
  // }
}
