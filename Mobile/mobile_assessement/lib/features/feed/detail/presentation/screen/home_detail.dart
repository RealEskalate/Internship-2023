import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter/src/widgets/placeholder.dart';
import 'package:flutter_svg/svg.dart';

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
                  child: Icon(Icons.arrow_back_ios, color: Colors.black))),
          title: Center(
              child: Column(
            children: [
              Text("New Mexico!",
                  style: myTextStyle.copyWith(
                      color: blackColor,
                      fontSize: 20,
                      fontWeight: FontWeight.w800)),
              Text("Sun, November 16",
                  style: myTextStyle.copyWith(
                      color: blackColor,
                      fontSize: 10,
                      fontWeight: FontWeight.w800))
            ],
          )),
          actions: [
            Padding(
              padding: EdgeInsets.only(
                  left: UIConverter.getComponentWidth(context, 10)),
              child: Icon(
                Icons.favorite_border_outlined,
                color: Colors.red,
              ),
            ),
          ],
        ),



        body: Container(
          child: Column(
            children: [
              Padding(
                padding: EdgeInsets.all(

                    UIConverter.getComponentHeight(context, 20)),
                child: Container(
                  child: SvgPicture.asset("images/weather1.jpg"),
                ),
              ),
              Container(
                child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [Text("Mostly Sunny"), Text("30")]),
              ),
              // Container(decoration: BoxDecoration(borderRadius: BorderRadius.only(topLeft:Radius.circular(  UIConverter.getComponentWidth(context,10))),
              // child:Container()
                         
              // ,)
              //   // Co
            ],
          ),
        )
        // body: Expanded(child:
        // ),
        );
  }
}
