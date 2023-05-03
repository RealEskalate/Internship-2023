import 'package:flutter/material.dart';

import '../../../../core/utils/colors.dart';


class StatusCard extends StatelessWidget {
  const StatusCard({super.key});

  @override
  Widget build(BuildContext context) {
    final screenHeight = MediaQuery.of(context).size.height;
    final screenWidth =  MediaQuery.of(context).size.width;
    final textSize =  MediaQuery.textScaleFactorOf(context);
    return Positioned(
        bottom: -0.03 * screenHeight,
        left: screenWidth * 0.085,
        child: SizedBox(
           width:screenWidth * 0.63,
            height: screenHeight * 0.1,
          child: Card(
           
            shape: RoundedRectangleBorder(
    borderRadius: BorderRadius.circular(15.0),),
    elevation: 30,
            child: Container(
                decoration: BoxDecoration(
                  color:BlueCardColor,
                  borderRadius: BorderRadius.circular(15),
                ),
                child: Padding(
                  padding: EdgeInsets.only(right:  screenWidth * 0.03),
                  child: Row(
                    mainAxisAlignment: MainAxisAlignment.spaceBetween,
                    children: [
                      Container(
                        width: screenWidth * 0.2,
                        height: screenHeight * 0.15,
                        decoration: BoxDecoration(
                          borderRadius: BorderRadius.circular(12),
                          color: Color.fromARGB(211, 10, 71, 151),
                        ),
                        child: Column(
                              mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                              children: [
                                Text("52",
                                    style: TextStyle(
                                        color: Colors.white,
                                        fontSize: 22 * textSize,
                                        fontWeight: FontWeight.w400,  fontFamily: 'Urbanist')),
                                 Text("Post",
                                    style: TextStyle(
                                        color: Colors.white,
                                        fontSize: 11 * textSize,
                                        fontWeight: FontWeight.w400,  fontFamily: 'Urbanist'))
                              ]),
                        
                      ),
                      Column(
                          mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                          children: [
                            Text("250",
                                style: TextStyle(
                                    color: Colors.white,
                                    fontSize: 22 * MediaQuery.textScaleFactorOf(context),
                                    fontWeight: FontWeight.w400,  fontFamily: 'Urbanist')),
                             Text("Following",
                                style: TextStyle(
                                    color: Colors.white,
                                    fontSize: 12 * MediaQuery.textScaleFactorOf(context),
                                    fontWeight: FontWeight.w400,  fontFamily: 'Urbanist'))
                          ]),
                      Column(
                          mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                          children: [
                            Text("4.5K",
                                style: TextStyle(
                                    color: Colors.white,
                                    fontSize: 22 * MediaQuery.textScaleFactorOf(context),
                                    fontWeight: FontWeight.w400,  fontFamily: 'Urbanist')),
                            Text("Followers",
                                style: TextStyle(
                                    color: Colors.white,
                                    fontSize: 12 * MediaQuery.textScaleFactorOf(context),
                                    fontWeight: FontWeight.w400,  fontFamily: 'Urbanist'))
                          ]),
                    ],
                  ),
                )),
          ),
        ));
  }
}