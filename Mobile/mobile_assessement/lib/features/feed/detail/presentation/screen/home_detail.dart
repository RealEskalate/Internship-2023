import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter/src/widgets/placeholder.dart';

import '../../../../../core/utils/colors.dart';
import '../../../../../core/utils/style.dart';
import '../../../../../core/utils/ui_converter.dart';

class MyWidget extends StatelessWidget {
  const MyWidget({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        elevation: 0,
        backgroundColor: whiteColor,
        leading: Padding(
            padding: EdgeInsets.only(
              bottom: UIConverter.getComponentHeight(context, 15),
              top: UIConverter.getComponentHeight(context, 15),
              right: UIConverter.getComponentWidth(context, 15),
              left: UIConverter.getComponentWidth(context, 15),
            ),
            child: Container(
                height: UIConverter.getComponentHeight(context, 35),
                width: UIConverter.getComponentWidth(context, 35),
                child: Icon(Icons.arrow_back_ios))),
        title: Center(
            child: Column(
              children:[ Text("New Mexico!",
                  style: myTextStyle.copyWith(
                      color: blackColor,
                      fontSize: 20,
                      fontWeight: FontWeight.w800)),
                      Text("Sun, November 16",style: myTextStyle.copyWith(
                      color: blackColor,
                      fontSize: 10,
                      fontWeight: FontWeight.w800) )
                      ],
            )
            ),
        actions: [Icon(Icons.favorite_border_outlined)],
        
      ),
    body: Expanded(child: Column(children: [
      Center(child: Image.asset("assets/images/weather1.jpg"),),
      Text("Mostly Sunny"),
      Text("30"),
      // Co


      
    ],)),
    );
  }
}