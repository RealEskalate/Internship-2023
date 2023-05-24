import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile_assessement/features/weather/presentation/bloc/weather_bloc.dart';

class CityOne {
  String name;
  double averageTemperature;
  String weatherIcon;
  String weatherDescription;

  CityOne(
      {required this.name,
      required this.averageTemperature,
      required this.weatherIcon,
      required this.weatherDescription
      });
}

class WeatherDay {
  String date;
  double minTemperature;
  double maxTemperature;
  String weatherIcon;

  WeatherDay({
    required this.date,
    required this.minTemperature,
    required this.maxTemperature,
    required this.weatherIcon,
  });
}

class WeatherDetailScreen extends StatelessWidget {
  final CityOne city;
  final List<WeatherDay> weatherForecast;

  WeatherDetailScreen({required this.city, required this.weatherForecast});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
          
          body: SafeArea(
            child: SingleChildScrollView(
          
              child: Padding(
                padding: EdgeInsets.all(16.0),
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Row(
                      mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                      children: [
                        IconButton(
                          icon: Icon(Icons.arrow_back_ios),
                          onPressed: () {
                            Navigator.pop(context);
                          },
                        ),
                        SizedBox(width: 14,),
                        Expanded(
                          child: Column(
                            crossAxisAlignment: CrossAxisAlignment.start,
                            children: [
                              Text(
                                city.name,
                                style: TextStyle(
                                    fontSize: 18.0, fontWeight: FontWeight.bold),
                              ),
                              Text(
                                ' ${DateTime.now().toString().substring(0, 10)}',
                                style: TextStyle(fontSize: 16.0),
                              ),
                            ],
                          ),
                        ),
                        IconButton(
                          icon: Icon(Icons.favorite),
                          onPressed: () {
                            // Handle favorite button press
                          },
                        ),
                      ],
                    ),
                    SizedBox(height: 16.0),
                    Center(child:  Image(image: NetworkImage( city.weatherIcon,), width: 200, height: 200,),),
                    // Image.asset(
                    //   "assets/images/rainy_lightning_windy_sunny.png", // Replace with your weather image asset
                    //   height: 100.0,
                    //   width: 100.0,
                    // ),
                    SizedBox(height: 8.0),
                    Text(
                      city.weatherDescription, // Replace with your weather description
                      style: TextStyle(fontSize: 24.0, color: Color(0XFF9F93FF)),
                    ),
                    SizedBox(height: 16.0),
                    Text(
                      '${city.averageTemperature}°C',
                      style: TextStyle(fontSize: 72.0, color: Color(0XFF211772) ),
                    ),
                    SizedBox(height: 20.0),
                    
                    Container(
                      decoration: BoxDecoration(
                        borderRadius: BorderRadius.only(topLeft: Radius.circular(20), topRight:Radius.circular(20) 
                        ),
                        color: Color(0XFF211772)
                      ),
                      child: ListView.builder(
                        shrinkWrap: true,
                        physics: NeverScrollableScrollPhysics(),
                        itemCount: weatherForecast.length,
                        itemBuilder: (context, index) {
                          final weatherDay = weatherForecast[index];
                          return GestureDetector(
                            child: Card(
                              color: Color(0XFF211772),
                              child: ListTile(
                                title: Row(
                                  mainAxisAlignment: MainAxisAlignment.spaceBetween,
                                  children: [ 
                                    
                                    Text(weatherDay.date.substring(0, 10), style: TextStyle(color: Color(0XFFFFFFFF)),),
                                    SizedBox(width: 8.0),
                                    
                                    Text(
                                  '${weatherDay.minTemperature}°C    ${weatherDay.maxTemperature}°C',
                                style: TextStyle(color: Color(0XFFFFFFFF)),),
                                Image(
                                  image: NetworkImage(weatherDay.weatherIcon),
                                  
                                  ),
                                  ],
                                ),
                              ),
                            ),
                          );
                        },
                      ),
                    ),
                  ],
                ),
              ),
            ),
          ),
        );
  }
}

// void main() {
//   runApp(MaterialApp(
//     title: 'Weather App',
//     home: WeatherDetailScreen(
//       city: City(name: 'New York', averageTemperature: 25.0, weatherIcon: Icons.wb_sunny),
//       weatherForecast: [
//         WeatherDay(date: '2023-05-23', minTemperature: 20.0, maxTemperature: 30.0, weatherIcon: Icons.wb_sunny),
//         WeatherDay(date: '2023-05-24', minTemperature: 18.0, maxTemperature: 28.0, weatherIcon: Icons.cloud),
//         WeatherDay(date: '2023-05-25', minTemperature: 22.0, maxTemperature: 32.0, weatherIcon: Icons.wb_sunny),
//       ],
//     ),
//   ));
// }
