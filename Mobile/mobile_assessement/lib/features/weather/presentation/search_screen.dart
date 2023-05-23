// import 'package:flutter/material.dart';
// import 'package:flutter/src/widgets/framework.dart';
// import 'package:flutter/src/widgets/placeholder.dart';

// class SearchScreen extends StatefulWidget {
//   const SearchScreen({super.key});

//   @override
//   State<SearchScreen> createState() => _SearchScreenState();
// }

// class _SearchScreenState extends State<SearchScreen> {
//   TextEditingController controllerValue = TextEditingController();

//   @override
//   Widget build(BuildContext context) {
//     return Scaffold(

//       body: SingleChildScrollView(
//         child: Column(
//           children: [
//              Text("Choose a city"),
//              Row(
//                children: [
//                 TextField(
//                   controller: controllerValue,
//                   decoration: InputDecoration(
//                     prefixIcon: GestureDetector(
//                       child: const Icon(
//                         Icons.add,
//                         textDirection: TextDirection.rtl,
//                       ),
//                     ),

//                     hintText: ("city"), //hint text
//                     //hint text style
//                     hintStyle:TextStyle(fontSize: 20), //hint text style

//                     hintMaxLines: 2, //hint text maximum lines
//                     hintTextDirection: TextDirection.ltr,

//                     //hint text direction, current is RTL
//                   ),
//                 ),
//                   ElevatedButton(onPressed: (){}, child: Text("Search"))

//                ],
//              ),

//           ],
//         ),
//       )
//     );
//   }
// }

import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile_assessement/features/weather/presentation/bloc/weather_bloc.dart';
import 'package:mobile_assessement/features/weather/presentation/city_detail_screen.dart';

class City {
  String name;
  double averageTemperature;
  IconData weatherIcon;

  City(
      {required this.name,
      required this.averageTemperature,
      required this.weatherIcon});
}

class SearchScreen extends StatefulWidget {
  @override
  State<SearchScreen> createState() => _SearchScreenState();
}

class _SearchScreenState extends State<SearchScreen> {
  final List<City> favoriteCities = [
    City(
        name: 'New York',
        averageTemperature: 25.0,
        weatherIcon: Icons.wb_sunny),
    City(name: 'London', averageTemperature: 20.0, weatherIcon: Icons.cloud),
    City(name: 'Paris', averageTemperature: 22.5, weatherIcon: Icons.wb_sunny),
    City(name: 'Tokyo', averageTemperature: 28.0, weatherIcon: Icons.wb_sunny),
  ];
  TextEditingController editingController = TextEditingController();
  @override
  Widget build(BuildContext context) {
    return BlocListener<WeatherBloc, WeatherState>(
      listener: (context, state) {
        // TODO: implement listener
      },
      
      child: MaterialApp(
        title: 'City Search',
        home: Scaffold(
          appBar: AppBar(
            title: Text('City Search'),
          ),
          body: SingleChildScrollView(
            child: Padding(
              padding: EdgeInsets.all(16.0),
              child: Column(
                children: [
                  Row(
                    children: [
                      Expanded(
                        child: TextField(
                          controller: editingController,
                          decoration: InputDecoration(
                            prefixIcon: Icon(Icons.search),
                            hintText: 'Search a new city',
                          ),
                        ),
                      ),
                      SizedBox(width: 16.0),
                      ElevatedButton(
                        onPressed: () {
                          BlocProvider.of<WeatherBloc>(context).add(
                              FetchWeatherEvent(city: editingController.text));
                          
                          Navigator.push(
                            context,
                            MaterialPageRoute(
                              builder: (context) => WeatherDetailScreen(
                                city: CityOne(
                                    name: 'New York',
                                    averageTemperature: 25.0,
                                    weatherIcon: Icons.wb_sunny),
                                weatherForecast: [
                                  WeatherDay(
                                      date: '2023-05-23',
                                      minTemperature: 20.0,
                                      maxTemperature: 30.0,
                                      weatherIcon: Icons.wb_sunny),
                                  WeatherDay(
                                      date: '2023-05-24',
                                      minTemperature: 18.0,
                                      maxTemperature: 28.0,
                                      weatherIcon: Icons.cloud),
                                  WeatherDay(
                                      date: '2023-05-25',
                                      minTemperature: 22.0,
                                      maxTemperature: 32.0,
                                      weatherIcon: Icons.wb_sunny),
                                ],
                              ),
                            ),
                          );
                        },
                        child: Text('Search'),
                      ),
                    ],
                  ),
                  SizedBox(height: 16.0),
                  Text(
                    'Favorite Cities',
                    style:
                        TextStyle(fontSize: 20.0, fontWeight: FontWeight.bold),
                  ),
                  SizedBox(height: 16.0),
                  ListView.builder(
                    shrinkWrap: true,
                    physics: NeverScrollableScrollPhysics(),
                    itemCount: favoriteCities.length,
                    itemBuilder: (context, index) {
                      return GestureDetector(
                          child: Card(
                            child: ListTile(
                              leading: Icon(favoriteCities[index].weatherIcon),
                              title: Text(favoriteCities[index].name),
                              subtitle: Text(
                                'Average Temperature: ${favoriteCities[index].averageTemperature}°C',
                              ),
                            ),
                          ),
                          onTap: () => Navigator.push(
                                context,
                                MaterialPageRoute(
                                  builder: (context) => WeatherDetailScreen(
                                    city: CityOne(
                                        name: 'New York',
                                        averageTemperature: 25.0,
                                        weatherIcon: Icons.wb_sunny),
                                    weatherForecast: [
                                      WeatherDay(
                                          date: '2023-05-23',
                                          minTemperature: 20.0,
                                          maxTemperature: 30.0,
                                          weatherIcon: Icons.wb_sunny),
                                      WeatherDay(
                                          date: '2023-05-24',
                                          minTemperature: 18.0,
                                          maxTemperature: 28.0,
                                          weatherIcon: Icons.cloud),
                                      WeatherDay(
                                          date: '2023-05-25',
                                          minTemperature: 22.0,
                                          maxTemperature: 32.0,
                                          weatherIcon: Icons.wb_sunny),
                                    ],
                                  ),
                                ),
                              ));
                    },
                  ),
                ],
              ),
            ),
          ),
        ),
      ),
    );
  }
}
