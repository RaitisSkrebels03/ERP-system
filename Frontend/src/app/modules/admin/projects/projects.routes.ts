import { Routes } from '@angular/router';
import { ProjectsListComponent } from './projects-list/projects-list.component';
import { ProjectDetailsComponent } from './project-details/project-details.component';
import { CreateProjectComponent } from './create-project/create-project.component';
import { UpdateProjectComponent } from './update-project/update-project.component';
import { CreateTaskComponent } from './create-task/create-task.component';
import { TasksListComponent } from './tasks-list/tasks-list.component';
import { TaskDetailsComponent } from './task-details/task-details.component';
import { UpdateTaskComponent } from './update-task/update-task.component';
export default [
    {
        path     : '',
        component: ProjectsListComponent,
    },
    {
        path     : 'details/:id',
        component: ProjectDetailsComponent,
    },
    {
        path     : 'create',
        component: CreateProjectComponent,
    },
    {
        path     : 'update/:id',
        component: UpdateProjectComponent,
    },
    {
        path     : 'createTask/:id',
        component: CreateTaskComponent,
    },
    {
        path     : 'tasks/:id',
        component: TasksListComponent,
    },
    {
        path     : 'task/:id',
        component: TaskDetailsComponent,
    },
    {
        path     : 'task/update/:id',
        component: UpdateTaskComponent,
    }
] as Routes;