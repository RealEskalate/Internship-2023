import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile_assessement/features/weatherify/presentation/screen/home_page.dart';

import '../../../../injection/injection.dart';
import '../bloc/bloc/weather_bloc.dart';

class WelcomePage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Color(0xff3C2DB9),
      body: Center(
        child: Column(

          mainAxisAlignment: MainAxisAlignment.spaceAround,
          children: [
            Image.network(
              'https://previews.123rf.com/images/virinka/virinka1112/virinka111200237/11499311-weather-hand-drawing-icons.jpg',
              width: 200,
              height: 200,
            ),
            SizedBox(height: 20),
            Padding(
              padding: const EdgeInsets.all(30.0),
              child: Container(
                width: double.infinity,
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Text(
                      'Weather',
                      style: TextStyle(
                        fontSize: 30,
                        fontWeight: FontWeight.bold,
                        color: Color(0xffFFBA25),// added this line
                      ),
                    ),
                    SizedBox(height: 10),
                    Text(
                      'Forecast App.',
                      style: TextStyle(
                        fontSize: 20,
                        color: Colors.white, // added this line
                      ),
                    ),
                  ],
                ),
              ),
            ),
            SizedBox(height: 20),
            Padding(
              padding: const EdgeInsets.symmetric(horizontal: 20),
              child: Text(
                "It's the newest weather app. It has a bunch of features and that includes most of the ones that every weather app has.",
                textAlign: TextAlign.center,
                style: TextStyle(
                  fontSize: 14,
                  color: Colors.white,
                ),
              ),
            ),
            SizedBox(height: 30),
            ElevatedButton(
              onPressed: () {
                Navigator.push(
                    context,
                    MaterialPageRoute(
                        builder: (context) => BlocProvider<WeatherBloc>(
                              create: (context) => WeatherBloc(sl()),
                              child: HomePage(),
                            )));
              },
              child: Text(
                'Get Started',
                style: TextStyle(
                  fontSize: 20,
                  fontWeight: FontWeight.bold,
                  color: Colors.white,
                ),
              ),
              style: ElevatedButton.styleFrom(
                primary: Color(0xffFFBA25),
                padding: EdgeInsets.symmetric(horizontal: 50, vertical: 15),
                shape: RoundedRectangleBorder(
                  borderRadius: BorderRadius.circular(10),
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
