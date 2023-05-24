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
    return MaterialApp(
      home: SafeArea(
        child: Scaffold(
          backgroundColor: Color(0XFFF2F2F2),
          body: SingleChildScrollView(
            child: Padding(
              padding: EdgeInsets.all(24.0),
              child: Column(
                mainAxisAlignment: MainAxisAlignment.start,
                children: [
                  Container(
                    child: Text("Choose a city", style: TextStyle(fontSize: 18,color: Color(0XFF211772)),),),
                  SizedBox(height: 31,),
                  Row(
                    children: [
                      
                      Expanded(
                        child: TextField(
                          
                          controller: editingController,
                          decoration: InputDecoration(
                            
                              border: OutlineInputBorder(
                                  borderRadius: BorderRadius.circular(7)),
                              prefixIcon: Icon(
                                Icons.search,
                                color: Color(0XFFD8D8D8),
                              ),
                              hintText: 'Search a new city...',
                              hintStyle: TextStyle(color: Color(0XFFD8D8D8))),
                        ),
                      ),
                      SizedBox(width: 16.0),
                      BlocConsumer<WeatherBloc, WeatherState>(
                        listener: (context, state) {
                          if (state is WeatherSuccess) {
                            Navigator.push(
                              context,
                              MaterialPageRoute(
                                builder: (context) => WeatherDetailScreen(
                                  city: CityOne(
                                      name: state.temperatureData.city,
                                      averageTemperature: double.parse(state
                                          .temperatureData
                                          .temperatureDataDetail[0]
                                          .avgTemp),
                                      weatherIcon:
                                          state.temperatureData.iconUrl,
                                      weatherDescription: state
                                          .temperatureData
                                          .temperatureDataDetail[0]
                                          .weatherDescription),
                                  weatherForecast: state
                                      .temperatureData.temperatureDataDetail
                                      .map((e) => WeatherDay(
                                          date: e.date.toString(),
                                          minTemperature:
                                              double.parse(e.minTemp),
                                          maxTemperature:
                                              double.parse(e.maxTemp),
                                          weatherIcon: e.iconUrl))
                                      .toList(),
                                ),
                              ),
                            );
                          } else if (state is WeatherFailure) {
                            ScaffoldMessenger.of(context).showSnackBar(
                              SnackBar(
                                content: Text("can't find city"),
                              ),
                            );
                          } else if (state is WeatherLoading) {
                            ScaffoldMessenger.of(context).showSnackBar(
                              SnackBar(
                                content: Text("Loading"),
                              ),
                            );
                          }
                        },
                        builder: (context, state) {
                          return GestureDetector(
                              child: Container(
                                width: 120,
                                height: 60,
                                decoration: BoxDecoration(
                                    color: Color(0xFFFFBA25),
                                    borderRadius: BorderRadius.circular(20)),
                                child: Center(
                                    child: const Text(
                                  "Search",
                                  style: TextStyle(
                                    fontSize: 20,
                                      color: Color.fromARGB(255, 236, 229, 229)),
                                )),
                              ),
                              onTap: () => {
                                BlocProvider.of<WeatherBloc>(context).add(
                                  FetchWeatherEvent(
                                      city: editingController.text))
                              }
                              );

                          
                        },
                      ),
                    ],
                  ),
                  SizedBox(height: 16.0),
                  Container(
                    child: Text(
                      'My Fav Citites',
                      style:
                          TextStyle(fontSize: 20.0, fontWeight: FontWeight.bold),
                    ),
                  ),
                  SizedBox(height: 16.0),
                  ListView.builder(
                    shrinkWrap: true,
                    physics: NeverScrollableScrollPhysics(),
                    itemCount: favoriteCities.length,
                    itemBuilder: (context, index) {
                      return Container(
                        margin: EdgeInsets.all(10),
                        padding: EdgeInsets.all(16),
                        decoration: BoxDecoration(
                          color: Color(0XFFFFFFFF),
                          borderRadius: BorderRadius.circular(12)
                        ),
                        height: 76,
                        width: double.infinity,
                        
                        child: Row(
                          mainAxisAlignment: MainAxisAlignment.spaceBetween,
                          children: [
                            Text(favoriteCities[index].name),
                            Row(
                              children: [Text(
                            '${favoriteCities[index].averageTemperature}°C',
                          ),
                          SizedBox(width: 13,),
                          Icon(favoriteCities[index].weatherIcon),
                          ],
                            ),
                            
                            ],
                        ),
                      );
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
