import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { LoggingService } from './core/services/logging.service';
import {EditorModule} from '@tinymce/tinymce-angular';


@Component({
    selector   : 'app-root',
    templateUrl: './app.component.html',
    styleUrls  : ['./app.component.scss'],
    standalone : true,
    imports    : [RouterOutlet, EditorModule]
})
export class AppComponent
{
    /**
     * Constructor
     */
    constructor(private loggingService: LoggingService)
    {
        //this.loggingService.error('hello');
    }
}
