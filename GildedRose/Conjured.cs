namespace GildedRose{
    public class Conjured : Item{
        public override void Update(){
            if(Quality > 0)
            {
                this.Quality = Math.Clamp(Quality-2,0,50);
                
            }
            this.SellIn--;
            if(SellIn < 0){
                this.Quality = Math.Clamp(Quality-2,0,50);
            }
        }

    }

}