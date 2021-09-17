import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutUsComponent } from './about-us/about-us.component';
import { AIPlannerComponent } from './ai-planner/ai-planner.component';
import { CovidQuestionnaireComponent } from './covid-questionnaire/covid-questionnaire.component';
import { HomepageComponent } from './homepage/homepage.component';
import { GuardsGuard } from '../app/guards/guards.guard';

const routes: Routes = [
  {
    path: "", component: HomepageComponent
  },
  {
    path: "about-us", component: AboutUsComponent
  },
  {
    path: "covid-questionnaire", component: CovidQuestionnaireComponent
  },
  {
    path: "ai-planner", component: AIPlannerComponent, canActivate: [GuardsGuard]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
