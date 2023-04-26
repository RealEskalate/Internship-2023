import 'package:flutter/material.dart';
class MySearchbar extends StatelessWidget {
  const MySearchbar({super.key});
  
  @override
  Widget build(BuildContext context) {
    Color _color =
        Color(int.parse("#669AFF".substring(1, 7), radix: 16) + 0xFF000000);
    return Padding(
      padding: EdgeInsets.only(left: 15, right: 15, top: 20, bottom: 10),
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
                          color: Color(
                              int.parse("#9A9494".substring(1, 7), radix: 16) +
                                  0xFF000000)),
                    ),
                    color: Colors.white,
                  ),
                  Container(
                    decoration: BoxDecoration(
                        color: _color, borderRadius: BorderRadius.circular(10)),
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
        ),
      ),
    );
  }
}
