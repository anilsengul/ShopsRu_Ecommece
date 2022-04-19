# ShopsRu_Ecommece
ShopsRu is the basic API for E-commerce system.
It has four endpoints:

1-Login

*User have to log in and then userId will add to Session called "uid". Other transactions will do by userId.

2-AddMembers

*Users can register to e-commerce system. They can be employee or member.

3-AddBasket

*Users add product to basket. If basket has same product which added before by user, this endpoint update quantity of product in basket.

4-GiveOrder

*Deleting all product that added by customer in basket. Creating random order number. Then insert orders table with order number. Also, insert all ordered products to order details table.
