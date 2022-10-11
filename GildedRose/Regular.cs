namespace GildedRose{

    public class Regular : Item{
        
        public override void Update(){
            SellIn--;
            if(Quality > 0){
                if(SellIn < 0){
                    Quality = Math.Clamp(Quality-2,0,50);
                }else{
                    Quality--;
                }
            }
            
        }

    }
}