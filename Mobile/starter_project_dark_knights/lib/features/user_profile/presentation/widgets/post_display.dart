import 'package:flutter/material.dart';

import '../../../../core/utils/colors.dart';
import 'package:flutter_svg/flutter_svg.dart';

class PostDisplay extends StatelessWidget {
  const PostDisplay({super.key});

  @override
  Widget build(BuildContext context) {
    final screenHeight = MediaQuery.of(context).size.height;
    final screenWidth = MediaQuery.of(context).size.width;
    final textSize = MediaQuery.textScaleFactorOf(context);
    return Container(
        decoration: const BoxDecoration(
          color: Colors.white,
          borderRadius: BorderRadius.only(
            topLeft: Radius.circular(30),
            topRight: Radius.circular(30),
          ),
        ),
        width: screenWidth * 1,
        height: screenHeight * 0.6,
        child: Column(
          children: [
            Padding(
              padding: EdgeInsets.fromLTRB(
                  screenWidth * 0.1,
                  screenHeight * 0.01,
                  screenWidth * 0.12,
                  screenHeight * 0.017),
              child: Row(
                children: [
                  Text(
                    "My Posts",
                    style: TextStyle(
                        fontSize: 18.0 * textSize,
                        fontWeight: FontWeight.w600,
                        fontFamily: 'Urbanist'),
                  ),
                  const Spacer(),
                  IconButton(
                    icon: SvgPicture.asset(
                      'assets/icons/4squares.svg',
                      color: primaryColor,
                      width: screenWidth * 0.025,
                      height: screenHeight * 0.025,
                    ),
                    onPressed: () {
                      // Do something when the user presses the button
                    },
                  ),
                  SizedBox(width: screenWidth * 0.05),
                  const Icon(
                    Icons.menu,
                    color: primaryColor,
                  )
                ],
              ),
            ),
            Expanded(
                child: Container(
                    width: screenWidth * 1,
                    height: screenHeight * 0.25,
                    child: ListView.builder(
                      itemCount: 10,
                      itemBuilder: (context, index) {
                        return Padding(
                          padding: EdgeInsets.fromLTRB(
                              screenWidth * 0.09,
                              screenHeight * 0.004,
                              screenWidth * 0.09,
                              screenHeight * 0.004),
                          child: Card(
                            shape: RoundedRectangleBorder(
                                borderRadius: BorderRadius.circular(30)),
                            elevation: 10,
                            shadowColor: Colors.grey[500],
                            child: Row(
                                mainAxisAlignment:
                                    MainAxisAlignment.spaceBetween,
                                children: [
                                  Container(
                                    width: MediaQuery.of(context).size.width *
                                        0.27,
                                    height: screenHeight * 0.2,
                                    child: ClipRRect(
                                      borderRadius: BorderRadius.circular(20),
                                      child: Image.network(
                                          "https://researchleap.com/wp-content/uploads/2023/03/0_QxsWlMTDGmTebavF.jpg",
                                          fit: BoxFit.cover),
                                    ),
                                  ),
                                  Column(
                                      crossAxisAlignment:
                                          CrossAxisAlignment.start,
                                      children: [
                                        Text(
                                          "BIG DATA",
                                          style: TextStyle(
                                              fontSize: 14.0 * textSize,
                                              fontStyle: FontStyle.italic,
                                              color: secondaryColor,
                                              fontWeight: FontWeight.normal,
                                              fontFamily: 'Urbanist'),
                                        ),
                                        SizedBox(height: screenHeight * 0.01),
                                        Container(
                                          width: screenWidth * 0.5,
                                          height: screenHeight * 0.09,
                                          child: Text(
                                            'Why Big Data Needs Thick Data ?',
                                            style: TextStyle(
                                                fontSize: 14.0 * textSize,
                                                fontWeight: FontWeight.w600,
                                                fontFamily: 'Urbanist'),
                                            overflow: TextOverflow.clip,
                                            softWrap: true,
                                          ),
                                        ),
                                        Row(
                                          mainAxisAlignment:
                                              MainAxisAlignment.spaceAround,
                                          children: [
                                            Row(
                                                mainAxisAlignment:
                                                    MainAxisAlignment
                                                        .spaceBetween,
                                                children: [
                                                  Icon(
                                                      Icons
                                                          .thumb_up_alt_outlined,
                                                      color: Colors.grey),
                                                  SizedBox(
                                                      width:
                                                          screenWidth * 0.009),
                                                  Text("2.1k",
                                                      style: TextStyle(
                                                          fontSize:
                                                              12 * textSize,
                                                          fontWeight:
                                                              FontWeight.w400))
                                                ]),
                                            SizedBox(width: screenWidth * 0.04),
                                            Row(
                                                mainAxisAlignment:
                                                    MainAxisAlignment
                                                        .spaceBetween,
                                                children: [
                                                  Icon(Icons.access_time),
                                                  SizedBox(
                                                      width:
                                                          screenWidth * 0.009),
                                                  Text("1hr ago",
                                                      style: TextStyle(
                                                          fontSize:
                                                              12 * textSize,
                                                          fontWeight:
                                                              FontWeight.w400))
                                                ]),
                                            SizedBox(width: screenWidth * 0.06),
                                            Icon(Icons.bookmark,
                                                color:
                                                    darkPrimaryColorGradient),
                                          ],
                                        )
                                      ])
                                ]),
                          ),
                        );
                      },
                    )))
          ],
        ));
  }
}
