import 'package:dartsmiths/core/utils/style.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter/src/widgets/placeholder.dart';

class ArticleCard extends StatelessWidget {
  const ArticleCard({super.key});

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: EdgeInsets.only(top: 70, left: 15, right: 15),
      child: Container(
        decoration: BoxDecoration(
          boxShadow: [
            BoxShadow(
              color: Colors.grey.withOpacity(0.3),
              spreadRadius: 5,
              blurRadius: 9,
              offset: Offset(0, 9),
            )
          ],
          borderRadius: BorderRadius.circular(30),
          color: Colors.white,
        ),
        width: double.infinity,
        height: 400,
        child: Container(
          width: double.infinity,
          child: Padding(
            padding: EdgeInsets.only(top: 0, bottom: 20),
            child: Column(
              mainAxisAlignment: MainAxisAlignment.spaceAround,
              children: [
                Row(
                  mainAxisAlignment: MainAxisAlignment.spaceAround,
                  children: [
                    Stack(
                      children: [
                        Padding(
                          padding: EdgeInsets.only(left: 10, right: 10),
                          child: Padding(
                            padding: EdgeInsets.only(top: 10),
                            child: Container(
                              width: 250,
                              height: 250,
                              decoration: BoxDecoration(
                                boxShadow: [
                                  BoxShadow(
                                    color: Colors.grey.withOpacity(0.3),
                                    spreadRadius: 5,
                                    blurRadius: 9,
                                    offset: Offset(0, 9),
                                  )
                                ],
                                borderRadius: BorderRadius.circular(20),
                                color: Colors.white,
                                image: new DecorationImage(
                                  image: new AssetImage(
                                      "assets/images/card_picture.jpg"),
                                  fit: BoxFit.cover,
                                ),
                              ),
                            ),
                          ),
                        ),
                        Padding(
                          padding: EdgeInsets.only(top: 22, left: 17),
                          child: Container(
                            width: 100,
                            height: 35,
                            decoration: BoxDecoration(
                                borderRadius: BorderRadius.circular(20),
                                color: Colors.white),
                            child: Center(
                              child: Text(
                                "5 min read",
                                style: myTextStyle.copyWith(
                                    fontWeight: FontWeight.w500,
                                    color: Color(0xFF424242)),
                              ),
                            ),
                          ),
                        ),
                      ],
                    ),
                    Padding(
                      padding: EdgeInsets.only(top: 5),
                      child: Column(
                        crossAxisAlignment: CrossAxisAlignment.start,
                        children: [
                          Padding(
                            padding: EdgeInsets.only(top: 0),
                            child: Padding(
                              padding: EdgeInsets.only(top: 10, bottom: 20),
                              child: Container(
                                // color: _color3,
                                child: Column(
                                  crossAxisAlignment: CrossAxisAlignment.start,
                                  children: [
                                    SizedBox(
                                      width: 200,
                                      child: Text(
                                        "Students should work on improving their writing skill"
                                            .toUpperCase(),
                                        style: myTextStyle.copyWith(
                                            fontWeight: FontWeight.normal,
                                            fontSize: 22,
                                            color: Color(0xFF4D4A49)),
                                      ),
                                    ),
                                    Padding(
                                      padding: EdgeInsets.only(top: 20),
                                      child: Container(
                                          decoration: BoxDecoration(
                                              color: Color(0xFF5E5F6F),
                                              borderRadius:
                                                  BorderRadius.circular(5)),
                                          width: 110,
                                          height: 30,
                                          child: Center(
                                              child: Text(
                                            "Education",
                                            style: myTextStyle.copyWith(
                                                fontSize: 15,
                                                fontWeight: FontWeight.w500,
                                                color: Colors.white),
                                          ))),
                                    ),
                                    Padding(
                                        padding: EdgeInsets.only(top: 25),
                                        child: Text(
                                          "by John Doe",
                                          style: myTextStyle.copyWith(
                                              fontSize: 18,
                                              fontWeight: FontWeight.w500,
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
                        padding: EdgeInsets.only(right: 20, top: 45, bottom: 0),
                        child: Text(
                          "Jan 12, 2022",
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
