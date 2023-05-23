import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile_assessement/features/weather_forcast/presentation/bloc/weather_event.dart';
import 'package:mobile_assessement/features/weather_forcast/presentation/screens/weather.dart';

import '../bloc/weather_bloc.dart';

class SearchCity extends StatelessWidget {
  const SearchCity({super.key});
  

  @override
  Widget build(BuildContext context) {
    final TextEditingController controller = TextEditingController();
    return Scaffold(
      backgroundColor:
          const Color(0xFFF2F2F2), // Sets the background color to #F2F2F2
      body: Column(
        children: <Widget>[
          const SizedBox(
            height: 50, // Sets the height of the top bar
            child: Center(
              child: Text(
                "Choose City", // Displays "Choose City" at the center
                style: TextStyle(
                  fontSize: 20,
                  fontWeight: FontWeight.bold,
                  color: Colors.black,
                ),
              ),
            ),
          ),
          Padding(
            padding: const EdgeInsets.all(16.0),
            child: TextField(
              controller: controller,
              decoration: InputDecoration(
                border: OutlineInputBorder(
                    borderRadius: BorderRadius.circular(10.0)),
                filled: true,
                fillColor: Colors.white,
                hintText: "Search",
                suffixIcon: IconButton(
                  onPressed: () {
                    context.read<WeatherBloc>().add(GetWeatherForecastEvent(controller.text));
                    Navigator.push(
                        context,
                        MaterialPageRoute(
                            builder: (context) => const WeatherScreen()));
                  },
                  icon: const Icon(
                    Icons.search,
                    size: 30,
                    color: Color(
                        0xFFFFBA25), // Sets the color of the search icon to #FFBA25
                  ),
                ),
              ),
            ),
          ),
        ],
      ),
    );
  }
}
