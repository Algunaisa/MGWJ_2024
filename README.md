# MGWJ_2024

# Project Design Document: Rupestralia(Sujeto a cambios)

-   **Created at**: 04/05/2024
-   **Author**: Guillermo Gutiérrez, Andrés Rafael, Jimmy Sirpa, Adonay Matehuala Corona,

## Project Concept

### Summary

Una restaudarora debe sortear diferentes dificultades para encontrar indicios de graficos rupetre de la Sierra de San Fransisco

### 1. Player Control

#### Table of Symbols

| Symbol | Meaning      |
| ------ | ------------ |
| Tab    | Mostrar guía |
| B      | Mochila      |

| User Input | Makes the player |
| ---------- | ---------------- |
| A          | Izquierda        |
| D          | Derecha          |
| SPACE BAR  | Saltar           |
| W          | Saltar           |

### 2. Basic Gameplay

During the game:

| Object type | Action type         | Condition                                         |
| ----------- | ------------------- | ------------------------------------------------- |
| Jabalí      | Arrancar y esquivar | Cuando estas cerca del jabalí te persigue y ataca |
| Serpiente   | Esquivar            | Cuando estas cerca te ataca                       |

### Game Goal

1. Completar la búsqueda de partes de las piezas de gráfico rupestre

### 3. Sounds & Effects

| Sonido Ambiental | Played when                                                                              |
| ---------------- | ---------------------------------------------------------------------------------------- |
| Desierto         | El nivel del desierto empieza                                                            |
| Cueva            | El jugador se encuentra en una cueva (La misma musica solo con efectos de eco [Ejemplo]) |

| Particle Effect     | Played when              |
| ------------------- | ------------------------ |
| Particula de tierra | Cuando el jugador camine |

| Enemy Sound         | Played when                                |
| ------------------- | ------------------------------------------ |
| Ataque de serpiente | Cuando la serpiente salte hacia el jugador |
| Embestida de Jabali | Cuando el Jabali corra hacia el jugador    |

### 4. Animaciones

| Animation | Played when                 |
| --------- | --------------------------- |
| Idle      | No hace nada                |
| Caminar   | when player walks on ground |
| Salto     | Cuando presiona space bar   |

| Animaciones Enemigas | Played when                  | Descripcion                                                                                                                               |
| -------------------- | ---------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------- |
| Jabalí Idle          | No ha detectado al jugador   | El jabali estara pastando levantando la cabeza despues de un ratoy moviendose en el lugar.                                                |
| Jabalí Embestir      | Cuando ve al jugador         | Mira al jugador se enoja y embiste hacia el agachando la cabeza, si le da levanta la cabeza, si no simplemente se vuelve a su estado idle |
| Serpiente Idle       | Cuando no detecte al jugador | Estará enrollada y camuflada con el bioma esperando al jugador                                                                            |
| Serpiente Salto      | Cuando detecta al jugador    | Saltará a dirección del jugador, si no ve al jugador vuelve a su estado de idle                                                           |

| Elementos Naturales | Played when |
| ------------------- | ----------- |
| Viento              |             |
| Temperatura         |             |

### 5. Gameplay Mechanics

As the game progresses:

| Description of gameplay mechanic | Effect on the game                              |
| -------------------------------- | ----------------------------------------------- |
| Viento                           | Mueve al jugador y al mural lo daña             |
| Temepartura                      | Daña al jugador                                 |
| Serpiente                        | Daña al jugador                                 |
| Jabalí                           | Daña y empuja al jugador                        |
| Botella de Agua                  | Cura daño al jugador                            |
| Botiquín                         | Cura daño al jugador                            |
| Mochila                          | Almacena objetos                                |
| Guía técnica                     | Muestra indicaciones de como restaurar          |
| Guía histórica                   | Muestra información histórica del arte rupestre |
| Polainas                         | Da resistencia ataques de serpiente             |

| Gameplay mechanic        | Description                                                                                    |
| ------------------------ | ---------------------------------------------------------------------------------------------- |
| Restaurar panel (Tipo 1) | Recuperar las piezas del panel                                                                 |
| Restaurar (Tipo 2)       | Combinacion de teclas para realizar el tipo de restaruración (Tipo Estratagemas de Helldivers) |
| Viento                   | Mueve al jugador y al mural lo daña                                                            |

### 6. User Interface

| Interface element | Action  | On Condition                 |
| ----------------- | ------- | ---------------------------- |
| Barra de salud    | Decrese | Cuando lo dañana un elemento |
| Barra de salud    | Crese   | Cuando utiliza botiquín      |

### 7. Other Features

**[ANY OTHER NOTES ABOUT THE PROJECT THAT YOU DON'T FEEL WERE ADDRESSED IN THE ABOVE.]**

## Project Timeline

| Milestone | Due date | Description       |
| --------- | -------- | ----------------- |
| #1        | 04/05    | Mini Game Jam     |
| #2        | 06/05    | Conceptualización |
| #3        | 13/05    | Prepoducción      |
| #4        | 27/05    | Producción I      |
| #5        | 08/06    | Testing           |
| #6        | 10/06    | Producción        |
| #7        | 24/06    | Postproducción    |
| #8        | 30/06    | Entrega final     |

### Backlog

| Feature/Task                                                     | Due date |
| ---------------------------------------------------------------- | -------- |
| Formación del GDD part II                                        | 06/05    |
| Feature on backlog #2 - not a part of the minimum viable product | mm/dd    |
| Feature on backlog #3 - not a part of the minimum viable product | mm/dd    |

### Team Rolls

| Member team | Roll           | Description |
| ----------- | -------------- | ----------- |
| Agustin     | Musica         |             |
| Luda        | Arte           |             |
| Isa         | Programador #1 |             |
| Guille      | Programador #2 |             |
| Jimbo       | Programador #3 |             |
| Andy        | Programador #4 |             |
| Adonay      | Investigacion  |             |
| Adonay      | UX             |             |

### Herramientas de Desarollo

| Herramienta           | Version   | Description                |
| --------------------- | --------- | -------------------------- |
| Unity                 | 2022.3.16 |                            |
| FL Studio             |           | Formato: Ogg Estilo: 8bits |
| Reaper                |           | Produccion de Sfx          |
| Pixel Studio(ejemplo) | ???       | 16 pixeles                 |
