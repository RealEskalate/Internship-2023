import 'package:flutter/material.dart';

class Introduction extends StatefulWidget {
  late String topic;
  late String content;
  late int currPage;
  late int totalPages;
  Introduction(this.topic, this.content, this.currPage, this.totalPages,
      {super.key});

  @override
  State<Introduction> createState() => _IntroductionState();
}

class _IntroductionState extends State<Introduction> {
  static const Color textColor = Color.fromARGB(255, 16, 27, 65);
  static const Color unselectedDotColor = Color.fromARGB(141, 33, 149, 243);
  static const Color selectedDotColor = Colors.blue;
  static const Color shadowColor = Color.fromARGB(166, 11, 59, 104);

  @override
  Widget build(BuildContext context) {
    var size = MediaQuery.of(context).size;
    return Container(
      width: size.width,
      padding: const EdgeInsets.only(top: 25, left: 50, right: 50),
      decoration: const BoxDecoration(
        color: Colors.white,
        boxShadow: [
          BoxShadow(
            color: shadowColor,
            spreadRadius: 1,
            blurRadius: 30,
            offset: Offset(-5, 5),
          ),
        ],
        borderRadius: BorderRadius.only(
          topLeft: Radius.circular(50),
          topRight: Radius.circular(50),
        ),
      ),
      child: Column(
        mainAxisAlignment: MainAxisAlignment.spaceAround,
        children: [
          Text(
            widget.topic,
            style: const TextStyle(
              color: textColor,
              fontSize: 30,
              fontFamily: "Poppins",
              fontWeight: FontWeight.w100,
              decoration: TextDecoration.none,
            ),
          ),
          Padding(
            padding: const EdgeInsets.only(top: 10),
            child: Text(
              widget.content,
              style: const TextStyle(
                color: textColor,
                fontSize: 15,
                fontFamily: "Poppins",
                decoration: TextDecoration.none,
              ),
            ),
          ),
          Row(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: [
              SizedBox(
                width: 100,
                height: 10,
                child: ListView.builder(
                  scrollDirection: Axis.horizontal,
                  itemCount: widget.totalPages,
                  itemBuilder: (context, index) {
                    return Container(
                      width: index + 1 == widget.currPage ? 25 : 10,
                      height: 10,
                      margin: const EdgeInsets.all(1),
                      decoration: BoxDecoration(
                        color: index + 1 == widget.currPage
                            ? selectedDotColor
                            : unselectedDotColor,
                        borderRadius: BorderRadius.circular(5),
                      ),
                    );
                  },
                ),
              ),
              Container(
                width: 100,
                height: 50,
                decoration: BoxDecoration(
                  color: Colors.blue,
                  borderRadius: BorderRadius.circular(10),
                ),
                child: TextButton(
                  onPressed: () {},
                  child: const Icon(
                    Icons.arrow_forward,
                    color: Colors.white,
                  ),
                ),
              )
            ],
          ),
        ],
      ),
    );
  }
}
