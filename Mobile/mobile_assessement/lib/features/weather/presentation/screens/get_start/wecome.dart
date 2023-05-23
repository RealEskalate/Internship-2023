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
        decoration: BoxDecoration(
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
          // mainAxisAlignment: MainAxisAlignment.start,
          // crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Positioned(
                width: 220,
                height: 220,
                left: 78,
                top: 143,
                child: Image.asset(logo)),
                SizedBox(height: UIConverter.getComponentHeight(context, 50),),
            Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: 
            [
              Positioned(
                height: 52,
                left: 0,
                right: MediaQuery.of(context).size.width * 0.457,
                top: MediaQuery.of(context).size.height * 0.5 - 52 / 2 - 65,
                child: Text(
                  'Weather',
                  style: TextStyle(
                    fontFamily: 'Roboto',
                    fontWeight: FontWeight.w500,
                    fontSize: 44,
                    height: 1.0,
                    color: Color(0xFFFFBA25),
                  ),
                ),
                
              ),
              SizedBox(height: UIConverter.getComponentHeight(context, 20),),
              Positioned(
                height: 42,
                left: 0,
                right: MediaQuery.of(context).size.width * 0.2583,
                top: MediaQuery.of(context).size.height * 0.5 - 42 / 2 - 13,
                child: Text(
                  'Forecast App.',
                  style: TextStyle(
                    fontFamily: 'Roboto',
                    fontWeight: FontWeight.w500,
                    fontSize: 36,
                    height: 1.0,
                    color: Colors.white,
                  ),
                ),
              ),
              SizedBox(height: UIConverter.getComponentHeight(context,20),),
              Positioned(
                left: 0,
                right: 0,
                top: MediaQuery.of(context).size.height * 0.6703,
                bottom: 0,
                child: Text(
                  'It\'s the newest weather app. It has a bunch of features and that includes most of the ones that every weather app has.',
                  style: TextStyle(
                    fontFamily: 'Roboto',
                    fontWeight: FontWeight.w400,
                    fontSize: 12,
                    height: 1.67,
                    color: Colors.white,
                  ),
                ),
              ),
              SizedBox(height: UIConverter.getComponentHeight(context, 50),),
            ]),
            Center(
              child: Container(
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
                  child: Text(
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
