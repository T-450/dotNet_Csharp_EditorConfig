import {ModuleWithProviders, NgModule} from '@angular/core';

import {SharedModule} from '../shared/shared.module';
import {BasketComponent} from './basket.component';
import {BasketStatusComponent} from './basket-status/basket-status.component';
import {BasketService} from './basket.service';

@NgModule({
    imports: [SharedModule],
    declarations: [BasketComponent, BasketStatusComponent],
    providers: [BasketService],
    exports: [BasketStatusComponent]
})
export class BasketModule {
    static forRoot(): ModuleWithProviders<BasketModule> {
        return {
            ngModule: BasketModule,
            providers: [
                // Providers
                BasketService
            ]
        };
    }
}