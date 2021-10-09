# Pokédex

This app exposes a REST API to perform CRUD operations on a Pokédex. A [CSV file](https://gist.github.com/armgilles/194bcff35001e7eb53a2a8b441e8b2c6) is loaded on startup and used as database.

Keep in mind that the `id` field required by the APIs is not the pokémon number, since multiple pokémons may have the same number (e.g. Charizard, CharizardMega Charizard X, CharizardMega Charizard Y).

## API

### GET `/api/pokedex/{id}`
##### Description
Get pokémon by id.
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| id | path |  | Yes | positive integer |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |
| 404 | Pokémon not found |

##### Successful response example
```json
{
  "id": 1,
  "#": 1,
  "name": "Bulbasaur",
  "type1": "Grass",
  "type2": "Poison",
  "total": 318,
  "hp": 45,
  "attack": 49,
  "defense": 49,
  "spAtk": 65,
  "spDef": 65,
  "speed": 45,
  "generation": 1,
  "legendary": false
}
```

### PUT `/api/pokedex/{id}`
##### Description
Update pokémon by id.
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| id | path |  | Yes | positive integer |

##### Example body
```json
{
  "number": 150,
  "name": "NewMewtwo",
  "type1": "Psychic",
  "type2": null,
  "hp": 300,
  "attack": 70,
  "defense": 80,
  "spAtk": 120,
  "spDef": 120,
  "speed": 150,
  "generation": 8,
  "legendary": true
}
```

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |
| 400 | Invalid request body |
| 400 | Invalid number |
| 400 | Invalid name |
| 400 | Invalid generation |

### DELETE `/api/pokedex/{id}`

##### Description
Update pokémon by id.

##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| id | path |  | Yes | positive integer |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |
| 404 | Pokémon not found |

### GET `/api/pokedex/all`

##### Description
Get paginated list with pokémons.

##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| pageNumber | query | Number of requested page. 0-based index. | No | integer |
| pageSize | query | Number of items per page. Cannot be greater than 50. | No | integer |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

##### Successful response example
```json
{
  "pageIndex": 0,
  "pageSize": 10,
  "totalCount": 800,
  "totalPages": 80,
  "result": [
    {
      "id": 1,
      "#": 1,
      "name": "Bulbasaur",
      "type1": "Grass",
      "type2": "Poison",
      "total": 318,
      "hp": 45,
      "attack": 49,
      "defense": 49,
      "spAtk": 65,
      "spDef": 65,
      "speed": 45,
      "generation": 1,
      "legendary": false
    },
    {
      "id": 2,
      "#": 2,
      "name": "Ivysaur",
      "type1": "Grass",
      "type2": "Poison",
      "total": 405,
      "hp": 60,
      "attack": 62,
      "defense": 63,
      "spAtk": 80,
      "spDef": 80,
      "speed": 60,
      "generation": 1,
      "legendary": false
    },
    {
      "id": 3,
      "#": 3,
      "name": "Venusaur",
      "type1": "Grass",
      "type2": "Poison",
      "total": 525,
      "hp": 80,
      "attack": 82,
      "defense": 83,
      "spAtk": 100,
      "spDef": 100,
      "speed": 80,
      "generation": 1,
      "legendary": false
    },
    {
      "id": 4,
      "#": 3,
      "name": "VenusaurMega Venusaur",
      "type1": "Grass",
      "type2": "Poison",
      "total": 625,
      "hp": 80,
      "attack": 100,
      "defense": 123,
      "spAtk": 122,
      "spDef": 120,
      "speed": 80,
      "generation": 1,
      "legendary": false
    },
    {
      "id": 5,
      "#": 4,
      "name": "Charmander",
      "type1": "Fire",
      "type2": null,
      "total": 309,
      "hp": 39,
      "attack": 52,
      "defense": 43,
      "spAtk": 60,
      "spDef": 50,
      "speed": 65,
      "generation": 1,
      "legendary": false
    },
    {
      "id": 6,
      "#": 5,
      "name": "Charmeleon",
      "type1": "Fire",
      "type2": null,
      "total": 405,
      "hp": 58,
      "attack": 64,
      "defense": 58,
      "spAtk": 80,
      "spDef": 65,
      "speed": 80,
      "generation": 1,
      "legendary": false
    },
    {
      "id": 7,
      "#": 6,
      "name": "Charizard",
      "type1": "Fire",
      "type2": "Flying",
      "total": 534,
      "hp": 78,
      "attack": 84,
      "defense": 78,
      "spAtk": 109,
      "spDef": 85,
      "speed": 100,
      "generation": 1,
      "legendary": false
    },
    {
      "id": 8,
      "#": 6,
      "name": "CharizardMega Charizard X",
      "type1": "Fire",
      "type2": "Dragon",
      "total": 634,
      "hp": 78,
      "attack": 130,
      "defense": 111,
      "spAtk": 130,
      "spDef": 85,
      "speed": 100,
      "generation": 1,
      "legendary": false
    },
    {
      "id": 9,
      "#": 6,
      "name": "CharizardMega Charizard Y",
      "type1": "Fire",
      "type2": "Flying",
      "total": 634,
      "hp": 78,
      "attack": 104,
      "defense": 78,
      "spAtk": 159,
      "spDef": 115,
      "speed": 100,
      "generation": 1,
      "legendary": false
    },
    {
      "id": 10,
      "#": 7,
      "name": "Squirtle",
      "type1": "Water",
      "type2": null,
      "total": 314,
      "hp": 44,
      "attack": 48,
      "defense": 65,
      "spAtk": 50,
      "spDef": 64,
      "speed": 43,
      "generation": 1,
      "legendary": false
    }
  ]
}
```

### POST `/api/pokedex`
##### Description
Create a new pokémon.

##### Example body
```json
{
  "number": 722,
  "name": "MewThree",
  "type1": "Psychic",
  "type2": null,
  "hp": 300,
  "attack": 70,
  "defense": 80,
  "spAtk": 120,
  "spDef": 120,
  "speed": 150,
  "generation": 8,
  "legendary": true
}
```

##### Successful response example
```json
{
  "id": 801,
  "#": 722,
  "name": "MewThree",
  "type1": "Psychic",
  "type2": null,
  "total": 840,
  "hp": 300,
  "attack": 70,
  "defense": 80,
  "spAtk": 120,
  "spDef": 120,
  "speed": 150,
  "generation": 8,
  "legendary": true
}
```

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |
| 400 | Invalid request body |
| 400 | Invalid number |
| 400 | Invalid name |
| 400 | Invalid generation |

### Models

#### Type

| Name | Type | Description | Required |
| ---- | ---- | ----------- | -------- |
| Type | string | Pokémon type | Yes |

#### UpdatePokemonRequest

| Name | Type | Description | Required |
| ---- | ---- | ----------- | -------- |
| number | positive integer |  | Yes |
| name | string |  | Yes |
| type1 | string | _Enum:_ `"Normal"`, `"Fighting"`, `"Flying"`, `"Poison"`, `"Ground"`, `"Rock"`, `"Bug"`, `"Ghost"`, `"Steel"`, `"Fire"`, `"Water"`, `"Grass"`, `"Electric"`, `"Psychic"`, `"Ice"`, `"Dragon"`, `"Dark"`, `"Fairy"` | Yes |
| type2 | string | _Enum:_ `"Normal"`, `"Fighting"`, `"Flying"`, `"Poison"`, `"Ground"`, `"Rock"`, `"Bug"`, `"Ghost"`, `"Steel"`, `"Fire"`, `"Water"`, `"Grass"`, `"Electric"`, `"Psychic"`, `"Ice"`, `"Dragon"`, `"Dark"`, `"Fairy"` | No |
| hp | positive integer |  | No |
| attack | positive integer |  | No |
| defense | positive integer |  | No |
| spAtk | positive integer |  | No |
| spDef | positive integer |  | No |
| speed | positive integer |  | No |
| generation | positive integer |  | Yes |
| legendary | boolean |  | No |

#### CreatePokemonRequest

| Name | Type | Description | Required |
| ---- | ---- | ----------- | -------- |
| number | positive integer |  | Yes |
| name | string |  | Yes |
| type1 | string | _Enum:_ `"Normal"`, `"Fighting"`, `"Flying"`, `"Poison"`, `"Ground"`, `"Rock"`, `"Bug"`, `"Ghost"`, `"Steel"`, `"Fire"`, `"Water"`, `"Grass"`, `"Electric"`, `"Psychic"`, `"Ice"`, `"Dragon"`, `"Dark"`, `"Fairy"` | Yes |
| type2 | string | _Enum:_ `"Normal"`, `"Fighting"`, `"Flying"`, `"Poison"`, `"Ground"`, `"Rock"`, `"Bug"`, `"Ghost"`, `"Steel"`, `"Fire"`, `"Water"`, `"Grass"`, `"Electric"`, `"Psychic"`, `"Ice"`, `"Dragon"`, `"Dark"`, `"Fairy"` | No |
| hp | positive integer |  | No |
| attack | positive integer |  | No |
| defense | positive integer |  | No |
| spAtk | positive integer |  | No |
| spDef | positive integer |  | No |
| speed | positive integer |  | No |
| generation | positive integer |  | Yes |
| legendary | boolean |  | No |
