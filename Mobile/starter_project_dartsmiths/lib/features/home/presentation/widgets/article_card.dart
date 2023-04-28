import 'package:dartsmiths/core/utils/style.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter/src/widgets/placeholder.dart';

import '../../../../core/utils/colors.dart';
import '../../../../core/utils/ui_converter.dart';

class ArticleCard extends StatelessWidget {
  const ArticleCard({super.key});

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: EdgeInsets.only(
          top: UIConverter.getComponentHeight(context, 70),
          left: UIConverter.getComponentWidth(context, 15),
          right: UIConverter.getComponentWidth(context, 15)),
      child: Container(
        decoration: BoxDecoration(
          boxShadow: [
            BoxShadow(
              color: Colors.grey.withOpacity(0.3),
              spreadRadius: UIConverter.getComponentWidth(context, 5),
              blurRadius: UIConverter.getComponentWidth(context, 9),
              offset: Offset(UIConverter.getComponentWidth(context, 0),
                  UIConverter.getComponentHeight(context, 9)),
            )
          ],
          borderRadius:
              BorderRadius.circular(UIConverter.getComponentWidth(context, 30)),
          color: whiteColor,
        ),
        width: double.infinity,
        height: UIConverter.getComponentWidth(context, 270),
        child: Container(
          width: double.infinity,
          child: Padding(
            padding: EdgeInsets.only(
                top: UIConverter.getComponentHeight(context, 0),
                bottom: UIConverter.getComponentHeight(context, 20)),
            child: Column(
              mainAxisAlignment: MainAxisAlignment.spaceAround,
              children: [
                Row(
                  mainAxisAlignment: MainAxisAlignment.spaceAround,
                  children: [
                    Stack(
                      children: [
                        Padding(
                          padding: EdgeInsets.only(
                              left: UIConverter.getComponentWidth(context, 10),
                              right:
                                  UIConverter.getComponentWidth(context, 20)),
                          child: Container(
                            width: UIConverter.getComponentWidth(context, 150),
                            height: UIConverter.getComponentWidth(context, 150),
                            decoration: BoxDecoration(
                              boxShadow: [
                                BoxShadow(
                                  color: Colors.grey.withOpacity(0.3),
                                  spreadRadius:
                                      UIConverter.getComponentWidth(context, 5),
                                  blurRadius:
                                      UIConverter.getComponentWidth(context, 9),
                                  offset: Offset(
                                      UIConverter.getComponentWidth(context, 0),
                                      UIConverter.getComponentHeight(
                                          context, 9)),
                                )
                              ],
                              borderRadius: BorderRadius.circular(
                                UIConverter.getComponentWidth(context, 20),
                              ),
                              color: whiteColor,
                              image: new DecorationImage(
                                image: new AssetImage(
                                    "assets/images/card_picture.jpg"),
                                fit: BoxFit.cover,
                              ),
                            ),
                          ),
                        ),
                        Padding(
                          padding: EdgeInsets.only(
                              top: UIConverter.getComponentHeight(context, 22),
                              left: UIConverter.getComponentWidth(context, 17)),
                          child: Container(
                            width: UIConverter.getComponentWidth(context, 100),
                            height: UIConverter.getComponentHeight(context, 35),
                            decoration: BoxDecoration(
                                borderRadius: BorderRadius.circular(
                                  UIConverter.getComponentWidth(context, 20),
                                ),
                                color: whiteColor),
                            child: Center(
                              child: Text(
                                "5 min read",
                                style: myTextStyle.copyWith(
                                    fontWeight: FontWeight.w500,
                                    // here
                                    color: Color(0xFF424242)),
                              ),
                            ),
                          ),
                        ),
                      ],
                    ),
                    Padding(
                      padding: EdgeInsets.only(
                          top: UIConverter.getComponentHeight(context, 5),
                          right: UIConverter.getComponentWidth(context, 30)),
                      child: Column(
                        crossAxisAlignment: CrossAxisAlignment.start,
                        children: [
                          Padding(
                            padding: EdgeInsets.only(
                                top:
                                    UIConverter.getComponentHeight(context, 0)),
                            child: Padding(
                              padding: EdgeInsets.only(
                                  top: UIConverter.getComponentHeight(
                                      context, 25),
                                  bottom: UIConverter.getComponentHeight(
                                      context, 20)),
                              child: Container(
                                child: Column(
                                  crossAxisAlignment: CrossAxisAlignment.start,
                                  children: [
                                    SizedBox(
                                      width: UIConverter.getComponentWidth(
                                          context, 130),
                                      child: Text(
                                        "Students should work on improving their writing skill"
                                            .toUpperCase(),
                                        style: myTextStyle.copyWith(
                                            fontWeight: FontWeight.normal,
                                            fontSize:
                                                UIConverter.getComponentWidth(
                                                        context, 18) *
                                                    (8 / 10),

                                            // here
                                            color: Color(0xFF4D4A49)),
                                      ),
                                    ),
                                    Padding(
                                      padding: EdgeInsets.only(
                                          top: UIConverter.getComponentHeight(
                                              context, 20)),
                                      child: Container(
                                          decoration: BoxDecoration(
                                              color: tertiaryColor,
                                              borderRadius:
                                                  BorderRadius.circular(
                                                      UIConverter
                                                          .getComponentWidth(
                                                              context, 5))),
                                          width: UIConverter.getComponentWidth(
                                              context, 80),
                                          height: UIConverter.getComponentWidth(
                                              context, 30),
                                          child: Center(
                                              child: Text(
                                            "Education",
                                            style: myTextStyle.copyWith(
                                                fontSize: UIConverter
                                                    .getComponentWidth(
                                                        context, 12),
                                                fontWeight: FontWeight.w500,
                                                color: whiteColor),
                                          ))),
                                    ),
                                    Padding(
                                        padding: EdgeInsets.only(
                                            top: UIConverter.getComponentHeight(
                                                context, 25)),
                                        child: Text(
                                          "by John Doe",
                                          style: myTextStyle.copyWith(
                                              fontSize:
                                                  UIConverter.getComponentWidth(
                                                      context, 14),
                                              fontWeight: FontWeight.w500,
                                              // here
                                              color: Color(0xFF424242)),
                                        )),
                                  ],
                                ),
                              ),
                            ),
                          ),
                        ],
                      ),
                    ),
                  ],
                ),
                Row(
                  mainAxisAlignment: MainAxisAlignment.end,
                  children: [
                    Padding(
                        padding: EdgeInsets.only(
                            right: UIConverter.getComponentWidth(context, 20),
                            top: UIConverter.getComponentHeight(context, 45),
                            bottom: UIConverter.getComponentHeight(context, 0)),
                        child: Text(
                          "Jan 12, 2022",
                          // here
                          style: myTextStyle.copyWith(color: Color(0xFF7D7D7D)),
                        ))
                  ],
                ),
              ],
            ),
          ),
        ),
      ),
    );
  }
}
