import 'package:flutter/material.dart';
import 'package:mobile_assessement/core/utils/images.dart';

import '../../../../../core/utils/ui_converter.dart';
import '../feed/home.dart';

class WeatherPage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Container(
        padding: EdgeInsets.fromLTRB(
            UIConverter.getComponentWidth(context, 40),
            UIConverter.getComponentHeight(context, 150),
            UIConverter.getComponentWidth(context, 32),
            UIConverter.getComponentHeight(context, 20)),
        decoration: const BoxDecoration(
          gradient: LinearGradient(
            begin: Alignment.topCenter,
            end: Alignment.bottomCenter,
            colors: [
              Color(0xFF3C2DB9),
              Color(0xFF211772),
            ],
          ),
        ),
        child: Column(
          children: [
            Image.asset(logo),
                SizedBox(height: UIConverter.getComponentHeight(context, 50),),
            Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: 
            [
                const Text(
                  'Weather',
                  style: TextStyle(
                    fontFamily: 'Roboto',
                    fontWeight: FontWeight.w500,
                    fontSize: 44,
                    height: 1.0,
                    color: Color(0xFFFFBA25),
                  ),
                ),
  
              SizedBox(height: UIConverter.getComponentHeight(context, 20),),
              const Text(
                  'Forecast App.',
                  style: TextStyle(
                    fontFamily: 'Roboto',
                    fontWeight: FontWeight.w500,
                    fontSize: 36,
                    height: 1.0,
                    color: Colors.white,
                  ),
                ),
              
              SizedBox(height: UIConverter.getComponentHeight(context,20),),
              const Text(
                  'It\'s the newest weather app. It has a bunch of features and that includes most of the ones that every weather app has.',
                  style: TextStyle(
                    fontFamily: 'Roboto',
                    fontWeight: FontWeight.w400,
                    fontSize: 12,
                    height: 1.67,
                    color: Colors.white,
                  ),
                ),
              SizedBox(height: UIConverter.getComponentHeight(context, 50),),
            ]),
            Center(
              child: Container(
                width: UIConverter.getComponentWidth(context, 200),
                decoration: BoxDecoration(
                  
                  color: Color(0xFFFFBA25),
                  borderRadius: BorderRadius.circular(10),
                ),
                child: TextButton(
                  onPressed: () {
                    Navigator.push(
                      context,
                      MaterialPageRoute(builder: (context) => HomePage()),
                    );
                  },
                  child: const Text(
                    style: TextStyle(
                      fontFamily: 'Roboto',
                      fontWeight: FontWeight.w500,
                      fontSize: 16,
                      height: 1.0,
                      color: Colors.white,
                    ),
                    'Get Started',
                  ),
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
