import 'package:flutter/material.dart';
import 'package:mobile_assessement/core/utils/images.dart';

import '../../../../../core/utils/ui_converter.dart';

class DetailPage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
        body: Container(
            padding: EdgeInsets.fromLTRB(
                UIConverter.getComponentWidth(context, 40),
                UIConverter.getComponentHeight(context, 80),
                UIConverter.getComponentWidth(context, 32),
                UIConverter.getComponentHeight(context, 20)),
            width: double.infinity,
            height: double.infinity,
            color: Color(0xFFF2F2F2),
            child: Column(children: [
              Row(
                children: [
                  Icon(Icons.arrow_back_ios),
                  SizedBox(
                    width: UIConverter.getComponentWidth(context, 50),
                  ),
                  Column(
                    // crossAxisAlignment: CrossAxisAlignment.center,  
                    children: const [
                      Text(
                        'New Mexico',
                        style: TextStyle(
                          fontFamily: 'Roboto',
                          fontWeight: FontWeight.w700,
                          fontSize: 18,
                          color: Color(0xFF211772),
                        ),
                        textAlign: TextAlign.center,
                      ),
                      SizedBox(height: 5),
                      Text(
                        'Sun, November 16',
                        style: TextStyle(
                          fontFamily: 'Roboto',
                          fontWeight: FontWeight.w400,
                          fontSize: 12,
                          color: Color(0xFF575757),
                        ),
                        textAlign: TextAlign.center,
                      ),
                    ],
                  ),
                ],
              ),
              SizedBox(
                height: UIConverter.getComponentHeight(context, 80),
              ),
              Image.asset(logo),
              Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: const [
                  Text(
                    'Mostly Sunny',
                    style: TextStyle(
                      fontFamily: 'Roboto',
                      fontWeight: FontWeight.w500,
                      fontSize: 24,
                      color: Color(0xFF9F93FF),
                    ),
                  ),
                  Text(
                    '30',
                    style: TextStyle(
                      fontFamily: 'Roboto',
                      fontWeight: FontWeight.w700,
                      fontSize: 72,
                      height: 1.17,
                      color: Color(0xFF211772),
                    ),
                  ),
                  
              //     Container(
              //   // width: UIConverter.getComponentWidth(context, 100),
              //   // height: double.infinity,
              //     decoration:
              //          BoxDecoration(color: Color(0xFF211772), boxShadow: [
              //   BoxShadow(
              //     offset: Offset(0, -4),
              //     blurRadius: 10,
              //     color: Color.fromRGBO(33, 23, 114, 0.203681),
              //   ),
              // ]
              // )
              // )
                ],
              ),
              
            ])));
  }
}
                  // borderRadius: BorderRadius.only(
                  //   topLeft: Radius