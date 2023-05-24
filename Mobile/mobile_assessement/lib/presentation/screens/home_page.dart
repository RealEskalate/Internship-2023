import 'package:flutter/material.dart';
import 'package:mobile_assessement/presentation/bloc/bloc/weather_event.dart';
import 'package:mobile_assessement/presentation/bloc/bloc/weather_state.dart';
import 'package:mobile_assessement/presentation/widgets/broadcast_card.dart';

import '../../../../core/utils/colors.dart';
import '../bloc/bloc/weather_bloc.dart';

class SplashScreen extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    final screenHeight = MediaQuery.of(context).size.height;
    final screenWidth = MediaQuery.of(context).size.width;
    final textSize = MediaQuery.textScaleFactorOf(context);
    return Scaffold(
      body: Container(
        width: double.infinity,
        height: double.infinity,
        color: Color.fromRGBO(30, 4, 231, 1),
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Padding(
              padding: EdgeInsets.only(left: 0.3 * screenWidth),
              child: Container(
                  height: screenHeight * 0.2,
                  width: screenWidth * 0.5,
                  child: Center(
                      child: Image.network(
                          'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQOKZdAHhBD986KmbHKbkkyM5UcGP6oSty11I1RW5eP7Rmploy1Wzu-b5o_-T-vVZKVALo&usqp=CAU'))),
            ),
            SizedBox(height: 10),
            Padding(
              padding: EdgeInsets.only(
                  left: 0.1 * screenWidth, top: 0.04 * screenHeight),
              child: Text('Weather',
                  style: TextStyle(
                    fontSize: 40 * textSize,
                    fontWeight: FontWeight.w500,
                    color: Colors.yellow,
                  )),
            ),
            SizedBox(height: 10),
            Padding(
              padding: EdgeInsets.only(left: 0.1 * screenWidth),
              child: Text('Forcast App',
                  style: TextStyle(
                    fontSize: 40 * textSize,
                    fontWeight: FontWeight.w500,
                    color: Colors.yellow,
                  )),
            ),
            Padding(
              padding:  EdgeInsets.only(top: 0.04 * screenHeight),
              child: Padding(
                padding:  EdgeInsets.only(left:  0.07 * screenWidth,right: 0.07* screenWidth),
                child: Text('some information about weather app'
                    'some information about weather app'
                    'some information about weather app',style: TextStyle(color: Colors.white),),
              ),
            ),
              ElevatedButton(
              onPressed: () {},
              child: Text('Get Started'),
            
             
            )
          ],
        ),
      ),
    );
  }
}
