import 'package:flutter/material.dart';

class ArticleImage extends StatelessWidget {
  const ArticleImage({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    final screenHeight = MediaQuery.of(context).size.height;
    return Stack(
      children: [
        Container(
            height: screenHeight * 0.18,
            decoration: BoxDecoration(
                borderRadius: BorderRadius.circular(10),
                image: const DecorationImage(
                    image: AssetImage("../../../assets/images/articlepic.jpg"),
                    fit: BoxFit.fill))),
        Padding(
          padding: const EdgeInsets.all(8.0),
          child: Container(
            width: 110,
            height: 30,
            decoration: BoxDecoration(
                color: Colors.white, borderRadius: BorderRadius.circular(10)),
            child: const Center(
                child: Text("5 min read",
                    style: TextStyle(
                      fontFamily: "Poppins",
                      fontWeight: FontWeight.w500,
                      color: Color(0xFF424242),
                    ))),
          ),
        )
      ],
    );
  }
}
