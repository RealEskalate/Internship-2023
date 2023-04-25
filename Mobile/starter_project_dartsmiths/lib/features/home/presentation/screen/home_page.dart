import 'package:flutter/material.dart';
import 'package:flutter_svg/svg.dart';

class HomePage extends StatelessWidget {
  const HomePage({super.key});

  @override
  Widget build(BuildContext context) {
    Color _color =
        Color(int.parse("#669AFF".substring(1, 7), radix: 16) + 0xFF000000);
    Color _color3 =
        Color(int.parse("#5E5F6F".substring(1, 7), radix: 16) + 0xFF000000);
    Color _color2 =
        Color(int.parse("#376AED".substring(1, 7), radix: 16) + 0xFF000000);
    return Scaffold(
      appBar: AppBar(
        elevation: 0,
        backgroundColor: Colors.white,
        leading: Stack(
          children: [
            Container(
                // child: SizedBox(
                //   height: 20,
                //   width: 20,
                //   child: SvgPicture.asset("menu.svg"),
                // ),
                ),
            Padding(
                padding: EdgeInsets.all(15),
                child: Container(
                    height: 35, width: 35, child: SvgPicture.asset("menu.svg")))
          ],
        ),
        title: Center(
            child: Text("Welcome  Back!",
                style: TextStyle(
                    color: Colors.black,
                    fontFamily: "Poppins",
                    fontSize: 25,
                    fontWeight: FontWeight.w800))),
        actions: [
          // Container(
          //   child: Image.asset(
          //     'assets/backgrd.jpg',
          //     fit: BoxFit.cover,
          //   ),
          //   decoration: BoxDecoration(
          //     borderRadius: BorderRadius.circular(300),
          //   ),
          // ),
          Padding(
              padding: EdgeInsets.only(right: 10, top: 5),
              child: Stack(
                children: [
                  CircleAvatar(
                      backgroundImage: AssetImage("assets/backgrd.jpg")),
                  Padding(
                    padding: EdgeInsets.only(left: 2.5, bottom: 12),
                    child: Column(
                        mainAxisAlignment: MainAxisAlignment.center,
                        children: [
                          Container(
                            decoration: BoxDecoration(
                                borderRadius: BorderRadius.circular(17),
                                border:
                                    Border.all(color: Colors.white, width: 2)),
                            width: 35,
                            height: 35,
                            // /color: Color.fromARGB(255, 31, 30, 28),
                          )
                        ]),
                  ),
                ],
              )),
        ],
      ),
      body: Container(
        height: double.infinity,
        child: Column(
          children: [
            Padding(
              padding:
                  EdgeInsets.only(left: 15, right: 15, top: 20, bottom: 10),
              child: Container(
                child: Container(
                  decoration: BoxDecoration(
                    color: Colors.white,
                    borderRadius: BorderRadius.circular(10),
                  ),
                  child: Padding(
                    padding: EdgeInsets.only(left: 20),
                    child: Row(
                        mainAxisAlignment: MainAxisAlignment.spaceBetween,
                        children: [
                          Container(
                            child: Text(
                              "Search and article ..",
                              style: TextStyle(
                                  letterSpacing: 1,
                                  fontFamily: "Poppins",
                                  fontWeight: FontWeight.w100,
                                  fontSize: 16,
                                  color: Color(int.parse(
                                          "#9A9494".substring(1, 7),
                                          radix: 16) +
                                      0xFF000000)),
                            ),
                            color: Colors.white,
                          ),
                          Container(
                            decoration: BoxDecoration(
                                color: _color,
                                borderRadius: BorderRadius.circular(10)),
                            width: 55,
                            height: 60,
                            child: IconButton(
                                onPressed: () => {},
                                icon: Icon(
                                  size: 35,
                                  Icons.search_sharp,
                                  color: Colors.white,
                                )),
                          ),
                        ]),
                  ),
                  width: double.infinity,
                  height: 220,
                ),
                width: double.infinity,
                height: 50,
                decoration: BoxDecoration(
                  boxShadow: [
                    BoxShadow(
                      color: Colors.grey.withOpacity(0.3),
                      spreadRadius: 5,
                      blurRadius: 9,
                      offset: Offset(0, 9),
                    )
                  ],
                  borderRadius: BorderRadius.circular(10),
                  // border: Border.all(color: Colors.black, width: 2),
                ),
              ),
            ),
            // Continue
            Padding(
              padding: EdgeInsets.only(top: 20, right: 25, left: 25),
              child: Row(
                mainAxisAlignment: MainAxisAlignment.spaceAround,
                children: [
                  Container(
                    decoration: BoxDecoration(
                        color: _color2,
                        borderRadius: BorderRadius.circular(120)),
                    width: 85,
                    height: 40,
                    child: Center(
                      child: Text(
                        "All",
                        style: TextStyle(
                            fontFamily: "Poppins", color: Colors.white),
                      ),
                    ),
                  ),
                  Container(
                    decoration: BoxDecoration(
                        color: Colors.white,
                        borderRadius: BorderRadius.circular(120),
                        border: Border.all(
                          color: _color2,
                          width: 2,
                        )),
                    width: 85,
                    height: 40,
                    child: Center(
                      child: Text(
                        "Sports",
                        style: TextStyle(fontFamily: "Poppins", color: _color2),
                      ),
                    ),
                  ),
                  Container(
                    decoration: BoxDecoration(
                        color: Colors.white,
                        borderRadius: BorderRadius.circular(120),
                        border: Border.all(
                          color: _color2,
                          width: 2,
                        )),
                    width: 85,
                    height: 40,
                    child: Center(
                      child: Text(
                        "Tech",
                        style: TextStyle(fontFamily: "Poppins", color: _color2),
                      ),
                    ),
                  ),
                  Container(
                    decoration: BoxDecoration(
                        color: Colors.white,
                        borderRadius: BorderRadius.circular(120),
                        border: Border.all(
                          color: _color2,
                          width: 2,
                        )),
                    width: 85,
                    height: 40,
                    child: Center(
                      child: Text(
                        "Politics",
                        style: TextStyle(fontFamily: "Poppins", color: _color2),
                      ),
                    ),
                  ),
                ],
              ),
            ),

            Expanded(
              child: ListView(
                children: [
                  Padding(
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
                                mainAxisAlignment:
                                    MainAxisAlignment.spaceAround,
                                children: [
                                  Row(
                                    mainAxisAlignment:
                                        MainAxisAlignment.spaceAround,
                                    children: [
                                      Stack(
                                        children: [
                                          Padding(
                                            padding: EdgeInsets.only(
                                                left: 10, right: 10),
                                            child: Padding(
                                              padding: EdgeInsets.only(top: 10),
                                              child: Container(
                                                width: 250,
                                                height: 250,
                                                decoration: BoxDecoration(
                                                  boxShadow: [
                                                    BoxShadow(
                                                      color: Colors.grey
                                                          .withOpacity(0.3),
                                                      spreadRadius: 5,
                                                      blurRadius: 9,
                                                      offset: Offset(0, 9),
                                                    )
                                                  ],
                                                  borderRadius:
                                                      BorderRadius.circular(20),
                                                  color: Colors.white,
                                                  image: new DecorationImage(
                                                    image: new AssetImage(
                                                        "assets/bas.jpg"),
                                                    fit: BoxFit.cover,
                                                  ),
                                                ),
                                              ),
                                            ),
                                          ),
                                          Padding(
                                            padding: EdgeInsets.only(
                                                top: 22, left: 17),
                                            child: Container(
                                              width: 100,
                                              height: 35,
                                              decoration: BoxDecoration(
                                                  borderRadius:
                                                      BorderRadius.circular(20),
                                                  color: Colors.white),
                                              child: Center(
                                                  child: Text(
                                                "5 min read",
                                                style: TextStyle(
                                                    fontWeight: FontWeight.w500,
                                                    fontFamily: "Poppins",
                                                    color: Color(int.parse(
                                                            "#424242".substring(
                                                                1, 7),
                                                            radix: 16) +
                                                        0xFF000000)),
                                              )),
                                            ),
                                          ),
                                        ],
                                      ),
                                      Padding(
                                        padding: EdgeInsets.only(top: 5),
                                        child: Column(
                                          crossAxisAlignment:
                                              CrossAxisAlignment.start,
                                          children: [
                                            Padding(
                                              padding: EdgeInsets.only(top: 0),
                                              child: Padding(
                                                padding: EdgeInsets.only(
                                                    top: 10, bottom: 20),
                                                child: Container(
                                                  // color: _color3,
                                                  child: Column(
                                                    crossAxisAlignment:
                                                        CrossAxisAlignment
                                                            .start,
                                                    children: [
                                                      SizedBox(
                                                        width: 200,
                                                        child: Text(
                                                          "Students should work on improving their writing skill"
                                                              .toUpperCase(),
                                                          style: TextStyle(
                                                              // letterSpacing: 1,
                                                              fontFamily:
                                                                  "Poppins",
                                                              fontWeight:
                                                                  FontWeight
                                                                      .normal,
                                                              fontSize: 22,
                                                              color: Color(int.parse(
                                                                      "#4D4A49"
                                                                          .substring(
                                                                              1,
                                                                              7),
                                                                      radix:
                                                                          16) +
                                                                  0xFF000000)),
                                                        ),
                                                      ),
                                                      Padding(
                                                        padding:
                                                            EdgeInsets.only(
                                                                top: 20),
                                                        child: Container(
                                                            decoration: BoxDecoration(
                                                                color: _color3,
                                                                borderRadius:
                                                                    BorderRadius
                                                                        .circular(
                                                                            5)),
                                                            width: 110,
                                                            height: 30,
                                                            child: Center(
                                                                child: Text(
                                                              "Education",
                                                              style: TextStyle(
                                                                  fontSize: 15,
                                                                  fontWeight:
                                                                      FontWeight
                                                                          .w500,
                                                                  fontFamily:
                                                                      "Poppins",
                                                                  color: Colors
                                                                      .white),
                                                            ))),
                                                      ),
                                                      Padding(
                                                          padding:
                                                              EdgeInsets.only(
                                                                  top: 25),
                                                          child: Text(
                                                            "by John Doe",
                                                            style: TextStyle(
                                                                fontFamily:
                                                                    "Poppins",
                                                                fontSize: 18,
                                                                fontWeight:
                                                                    FontWeight
                                                                        .w500,
                                                                color: Color(int.parse(
                                                                        "#424242".substring(
                                                                            1,
                                                                            7),
                                                                        radix:
                                                                            16) +
                                                                    0xFF000000)),
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
                                              right: 20, top: 45, bottom: 0),
                                          child: Text(
                                            "Jan 12, 2022",
                                            style: TextStyle(
                                                fontFamily: "Poppins",
                                                color: Color(int.parse(
                                                        "#7D7D7D"
                                                            .substring(1, 7),
                                                        radix: 16) +
                                                    0xFF000000)),
                                          ))
                                    ],
                                  ),
                                ],
                              ),
                            ),
                          ))),
                  Padding(
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
                                mainAxisAlignment:
                                    MainAxisAlignment.spaceAround,
                                children: [
                                  Row(
                                    mainAxisAlignment:
                                        MainAxisAlignment.spaceAround,
                                    children: [
                                      Stack(
                                        children: [
                                          Padding(
                                            padding: EdgeInsets.only(
                                                left: 10, right: 10),
                                            child: Padding(
                                              padding: EdgeInsets.only(top: 10),
                                              child: Container(
                                                width: 250,
                                                height: 250,
                                                decoration: BoxDecoration(
                                                  boxShadow: [
                                                    BoxShadow(
                                                      color: Colors.grey
                                                          .withOpacity(0.3),
                                                      spreadRadius: 5,
                                                      blurRadius: 9,
                                                      offset: Offset(0, 9),
                                                    )
                                                  ],
                                                  borderRadius:
                                                      BorderRadius.circular(20),
                                                  color: Colors.white,
                                                  image: new DecorationImage(
                                                    image: new AssetImage(
                                                        "assets/bas.jpg"),
                                                    fit: BoxFit.cover,
                                                  ),
                                                ),
                                              ),
                                            ),
                                          ),
                                          Padding(
                                            padding: EdgeInsets.only(
                                                top: 22, left: 17),
                                            child: Container(
                                              width: 100,
                                              height: 35,
                                              decoration: BoxDecoration(
                                                  borderRadius:
                                                      BorderRadius.circular(20),
                                                  color: Colors.white),
                                              child: Center(
                                                  child: Text(
                                                "5 min read",
                                                style: TextStyle(
                                                    fontWeight: FontWeight.w500,
                                                    fontFamily: "Poppins",
                                                    color: Color(int.parse(
                                                            "#424242".substring(
                                                                1, 7),
                                                            radix: 16) +
                                                        0xFF000000)),
                                              )),
                                            ),
                                          ),
                                        ],
                                      ),
                                      Padding(
                                        padding: EdgeInsets.only(top: 5),
                                        child: Column(
                                          crossAxisAlignment:
                                              CrossAxisAlignment.start,
                                          children: [
                                            Padding(
                                              padding: EdgeInsets.only(top: 0),
                                              child: Padding(
                                                padding: EdgeInsets.only(
                                                    top: 10, bottom: 20),
                                                child: Container(
                                                  // color: _color3,
                                                  child: Column(
                                                    crossAxisAlignment:
                                                        CrossAxisAlignment
                                                            .start,
                                                    children: [
                                                      SizedBox(
                                                        width: 200,
                                                        child: Text(
                                                          "Students should work on improving their writing skill"
                                                              .toUpperCase(),
                                                          style: TextStyle(
                                                              // letterSpacing: 1,
                                                              fontFamily:
                                                                  "Poppins",
                                                              fontWeight:
                                                                  FontWeight
                                                                      .normal,
                                                              fontSize: 22,
                                                              color: Color(int.parse(
                                                                      "#4D4A49"
                                                                          .substring(
                                                                              1,
                                                                              7),
                                                                      radix:
                                                                          16) +
                                                                  0xFF000000)),
                                                        ),
                                                      ),
                                                      Padding(
                                                        padding:
                                                            EdgeInsets.only(
                                                                top: 20),
                                                        child: Container(
                                                            decoration: BoxDecoration(
                                                                color: _color3,
                                                                borderRadius:
                                                                    BorderRadius
                                                                        .circular(
                                                                            5)),
                                                            width: 110,
                                                            height: 30,
                                                            child: Center(
                                                                child: Text(
                                                              "Education",
                                                              style: TextStyle(
                                                                  fontSize: 15,
                                                                  fontWeight:
                                                                      FontWeight
                                                                          .w500,
                                                                  fontFamily:
                                                                      "Poppins",
                                                                  color: Colors
                                                                      .white),
                                                            ))),
                                                      ),
                                                      Padding(
                                                          padding:
                                                              EdgeInsets.only(
                                                                  top: 25),
                                                          child: Text(
                                                            "by John Doe",
                                                            style: TextStyle(
                                                                fontFamily:
                                                                    "Poppins",
                                                                fontSize: 18,
                                                                fontWeight:
                                                                    FontWeight
                                                                        .w500,
                                                                color: Color(int.parse(
                                                                        "#424242".substring(
                                                                            1,
                                                                            7),
                                                                        radix:
                                                                            16) +
                                                                    0xFF000000)),
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
                                              right: 20, top: 45, bottom: 0),
                                          child: Text(
                                            "Jan 12, 2022",
                                            style: TextStyle(
                                                fontFamily: "Poppins",
                                                color: Color(int.parse(
                                                        "#7D7D7D"
                                                            .substring(1, 7),
                                                        radix: 16) +
                                                    0xFF000000)),
                                          ))
                                    ],
                                  ),
                                ],
                              ),
                            ),
                          ))),
                  SizedBox(
                    height: 70,
                  ),
                  Padding(
                      padding: EdgeInsets.only(bottom: 10, right: 30, top: 55),
                      child: Row(
                          mainAxisAlignment: MainAxisAlignment.end,
                          children: [
                            Container(
                              decoration: BoxDecoration(
                                  color: _color,
                                  borderRadius: BorderRadius.circular(10)),
                              width: 55,
                              height: 55,
                              child: IconButton(
                                  onPressed: () => {},
                                  icon: Icon(
                                    size: 25,
                                    Icons.add,
                                    color: Colors.white,
                                  )),
                            ),
                          ]))
                ],
              ),
            ),
          ],
        ),
      ),

      // ],
      // ),
    );
  }
}